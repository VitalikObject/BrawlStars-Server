using System;

namespace BrawlStars.Utilities.Compression.ZLib
{
    internal static class InternalInflateConstants
    {
        internal static readonly int[] InflateMask =
        {
            0x00000000, 0x00000001, 0x00000003, 0x00000007,
            0x0000000f, 0x0000001f, 0x0000003f, 0x0000007f,
            0x000000ff, 0x000001ff, 0x000003ff, 0x000007ff,
            0x00000fff, 0x00001fff, 0x00003fff, 0x00007fff, 0x0000ffff
        };
    }

    internal sealed class InflateBlocks
    {
        private const int Many = 1440;

        internal static readonly int[] Border = {16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15};
        private InflateBlockMode _mode;
        internal int[] Bb = new int[1];
        internal int Bitb;
        internal int Bitk;
        internal int[] Blens;
        internal uint Check;
        internal object Checkfn;

        internal ZlibCodec Codec;
        internal InflateCodes Codes = new InflateCodes();
        internal int End;
        internal int[] Hufts;
        internal int Index;
        internal InfTree Inftree = new InfTree();
        internal int Last;
        internal int Left;
        internal int ReadAt;
        internal int Table;
        internal int[] Tb = new int[1];
        internal byte[] Window;
        internal int WriteAt;

        internal InflateBlocks(ZlibCodec codec, object checkfn, int w)
        {
            Codec = codec;
            Hufts = new int[Many * 3];
            Window = new byte[w];
            End = w;
            Checkfn = checkfn;
            _mode = InflateBlockMode.TYPE;
            Reset();
        }

        internal int Flush(int r)
        {
            for (var pass = 0; pass < 2; pass++)
            {
                int nBytes;
                if (pass == 0)
                    nBytes = (ReadAt <= WriteAt ? WriteAt : End) - ReadAt;
                else
                    nBytes = WriteAt - ReadAt;

                if (nBytes == 0)
                {
                    if (r == ZlibConstants.ZBufError)
                        r = ZlibConstants.ZOk;
                    return r;
                }

                if (nBytes > Codec.AvailableBytesOut)
                    nBytes = Codec.AvailableBytesOut;

                if (nBytes != 0 && r == ZlibConstants.ZBufError)
                    r = ZlibConstants.ZOk;

                Codec.AvailableBytesOut -= nBytes;
                Codec.TotalBytesOut += nBytes;

                if (Checkfn != null)
                    Codec._Adler32 = Check = Adler.Adler32(Check, Window, ReadAt, nBytes);

                Array.Copy(Window, ReadAt, Codec.OutputBuffer, Codec.NextOut, nBytes);
                Codec.NextOut += nBytes;
                ReadAt += nBytes;

                if (ReadAt == End && pass == 0)
                {
                    ReadAt = 0;
                    if (WriteAt == End)
                        WriteAt = 0;
                }
                else
                {
                    pass++;
                }
            }

            return r;
        }

        internal void Free()
        {
            Reset();
            Window = null;
            Hufts = null;
        }

        internal int Process(int r)
        {
            int t;

            var p = Codec.NextIn;
            var n = Codec.AvailableBytesIn;
            var b = Bitb;
            var k = Bitk;

            var q = WriteAt;
            var m = q < ReadAt ? ReadAt - q - 1 : End - q;

            while (true)
                switch (_mode)
                {
                    case InflateBlockMode.TYPE:

                        while (k < 3)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                Bitb = b;
                                Bitk = k;
                                Codec.AvailableBytesIn = n;
                                Codec.TotalBytesIn += p - Codec.NextIn;
                                Codec.NextIn = p;
                                WriteAt = q;
                                return Flush(r);
                            }

                            n--;
                            b |= (Codec.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        t = b & 7;
                        Last = t & 1;

                        switch ((uint) t >> 1)
                        {
                            case 0:
                                b >>= 3;
                                k -= 3;
                                t = k & 7;
                                b >>= t;
                                k -= t;
                                _mode = InflateBlockMode.LENS;
                                break;

                            case 1:
                                var bl = new int[1];
                                var bd = new int[1];
                                var tl = new int[1][];
                                var td = new int[1][];
                                InfTree.Inflate_trees_fixed(bl, bd, tl, td, Codec);
                                Codes.Init(bl[0], bd[0], tl[0], 0, td[0], 0);
                                b >>= 3;
                                k -= 3;
                                _mode = InflateBlockMode.CODES;
                                break;

                            case 2:
                                b >>= 3;
                                k -= 3;
                                _mode = InflateBlockMode.TABLE;
                                break;

                            case 3:
                                b >>= 3;
                                k -= 3;
                                _mode = InflateBlockMode.BAD;
                                Codec.Message = "invalid block type";
                                r = ZlibConstants.ZDataError;
                                Bitb = b;
                                Bitk = k;
                                Codec.AvailableBytesIn = n;
                                Codec.TotalBytesIn += p - Codec.NextIn;
                                Codec.NextIn = p;
                                WriteAt = q;
                                return Flush(r);
                        }

                        break;

                    case InflateBlockMode.LENS:

                        while (k < 32)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                Bitb = b;
                                Bitk = k;
                                Codec.AvailableBytesIn = n;
                                Codec.TotalBytesIn += p - Codec.NextIn;
                                Codec.NextIn = p;
                                WriteAt = q;
                                return Flush(r);
                            }

                            ;
                            n--;
                            b |= (Codec.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        if (((~b >> 16) & 0xffff) != (b & 0xffff))
                        {
                            _mode = InflateBlockMode.BAD;
                            Codec.Message = "invalid stored block lengths";
                            r = ZlibConstants.ZDataError;

                            Bitb = b;
                            Bitk = k;
                            Codec.AvailableBytesIn = n;
                            Codec.TotalBytesIn += p - Codec.NextIn;
                            Codec.NextIn = p;
                            WriteAt = q;
                            return Flush(r);
                        }

                        Left = b & 0xffff;
                        b = k = 0;
                        _mode = Left != 0
                            ? InflateBlockMode.STORED
                            : Last != 0
                                ? InflateBlockMode.DRY
                                : InflateBlockMode.TYPE;
                        break;

                    case InflateBlockMode.STORED:
                        if (n == 0)
                        {
                            Bitb = b;
                            Bitk = k;
                            Codec.AvailableBytesIn = n;
                            Codec.TotalBytesIn += p - Codec.NextIn;
                            Codec.NextIn = p;
                            WriteAt = q;
                            return Flush(r);
                        }

                        if (m == 0)
                        {
                            if (q == End && ReadAt != 0)
                            {
                                q = 0;
                                m = q < ReadAt ? ReadAt - q - 1 : End - q;
                            }

                            if (m == 0)
                            {
                                WriteAt = q;
                                r = Flush(r);
                                q = WriteAt;
                                m = q < ReadAt ? ReadAt - q - 1 : End - q;
                                if (q == End && ReadAt != 0)
                                {
                                    q = 0;
                                    m = q < ReadAt ? ReadAt - q - 1 : End - q;
                                }

                                if (m == 0)
                                {
                                    Bitb = b;
                                    Bitk = k;
                                    Codec.AvailableBytesIn = n;
                                    Codec.TotalBytesIn += p - Codec.NextIn;
                                    Codec.NextIn = p;
                                    WriteAt = q;
                                    return Flush(r);
                                }
                            }
                        }

                        r = ZlibConstants.ZOk;

                        t = Left;
                        if (t > n)
                            t = n;
                        if (t > m)
                            t = m;
                        Array.Copy(Codec.InputBuffer, p, Window, q, t);
                        p += t;
                        n -= t;
                        q += t;
                        m -= t;
                        if ((Left -= t) != 0)
                            break;

                        _mode = Last != 0 ? InflateBlockMode.DRY : InflateBlockMode.TYPE;
                        break;

                    case InflateBlockMode.TABLE:

                        while (k < 14)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                Bitb = b;
                                Bitk = k;
                                Codec.AvailableBytesIn = n;
                                Codec.TotalBytesIn += p - Codec.NextIn;
                                Codec.NextIn = p;
                                WriteAt = q;
                                return Flush(r);
                            }

                            n--;
                            b |= (Codec.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        Table = t = b & 0x3fff;
                        if ((t & 0x1f) > 29 || ((t >> 5) & 0x1f) > 29)
                        {
                            _mode = InflateBlockMode.BAD;
                            Codec.Message = "too many length or distance symbols";
                            r = ZlibConstants.ZDataError;

                            Bitb = b;
                            Bitk = k;
                            Codec.AvailableBytesIn = n;
                            Codec.TotalBytesIn += p - Codec.NextIn;
                            Codec.NextIn = p;
                            WriteAt = q;
                            return Flush(r);
                        }

                        t = 258 + (t & 0x1f) + ((t >> 5) & 0x1f);
                        if (Blens == null || Blens.Length < t) Blens = new int[t];
                        else
                            Array.Clear(Blens, 0, t);

                        b >>= 14;
                        k -= 14;

                        Index = 0;
                        _mode = InflateBlockMode.BTREE;
                        goto case InflateBlockMode.BTREE;

                    case InflateBlockMode.BTREE:
                        while (Index < 4 + (Table >> 10))
                        {
                            while (k < 3)
                            {
                                if (n != 0)
                                {
                                    r = ZlibConstants.ZOk;
                                }
                                else
                                {
                                    Bitb = b;
                                    Bitk = k;
                                    Codec.AvailableBytesIn = n;
                                    Codec.TotalBytesIn += p - Codec.NextIn;
                                    Codec.NextIn = p;
                                    WriteAt = q;
                                    return Flush(r);
                                }

                                n--;
                                b |= (Codec.InputBuffer[p++] & 0xff) << k;
                                k += 8;
                            }

                            Blens[Border[Index++]] = b & 7;

                            b >>= 3;
                            k -= 3;
                        }

                        while (Index < 19) Blens[Border[Index++]] = 0;

                        Bb[0] = 7;
                        t = Inftree.Inflate_trees_bits(Blens, Bb, Tb, Hufts, Codec);
                        if (t != ZlibConstants.ZOk)
                        {
                            r = t;
                            if (r == ZlibConstants.ZDataError)
                            {
                                Blens = null;
                                _mode = InflateBlockMode.BAD;
                            }

                            Bitb = b;
                            Bitk = k;
                            Codec.AvailableBytesIn = n;
                            Codec.TotalBytesIn += p - Codec.NextIn;
                            Codec.NextIn = p;
                            WriteAt = q;
                            return Flush(r);
                        }

                        Index = 0;
                        _mode = InflateBlockMode.DTREE;
                        goto case InflateBlockMode.DTREE;

                    case InflateBlockMode.DTREE:
                        while (true)
                        {
                            t = Table;
                            if (!(Index < 258 + (t & 0x1f) + ((t >> 5) & 0x1f))) break;

                            t = Bb[0];

                            while (k < t)
                            {
                                if (n != 0)
                                {
                                    r = ZlibConstants.ZOk;
                                }
                                else
                                {
                                    Bitb = b;
                                    Bitk = k;
                                    Codec.AvailableBytesIn = n;
                                    Codec.TotalBytesIn += p - Codec.NextIn;
                                    Codec.NextIn = p;
                                    WriteAt = q;
                                    return Flush(r);
                                }

                                n--;
                                b |= (Codec.InputBuffer[p++] & 0xff) << k;
                                k += 8;
                            }

                            t = Hufts[(Tb[0] + (b & InternalInflateConstants.InflateMask[t])) * 3 + 1];
                            var c = Hufts[(Tb[0] + (b & InternalInflateConstants.InflateMask[t])) * 3 + 2];

                            if (c < 16)
                            {
                                b >>= t;
                                k -= t;
                                Blens[Index++] = c;
                            }
                            else
                            {
                                var i = c == 18 ? 7 : c - 14;
                                var j = c == 18 ? 11 : 3;

                                while (k < t + i)
                                {
                                    if (n != 0)
                                    {
                                        r = ZlibConstants.ZOk;
                                    }
                                    else
                                    {
                                        Bitb = b;
                                        Bitk = k;
                                        Codec.AvailableBytesIn = n;
                                        Codec.TotalBytesIn += p - Codec.NextIn;
                                        Codec.NextIn = p;
                                        WriteAt = q;
                                        return Flush(r);
                                    }

                                    n--;
                                    b |= (Codec.InputBuffer[p++] & 0xff) << k;
                                    k += 8;
                                }

                                b >>= t;
                                k -= t;

                                j += b & InternalInflateConstants.InflateMask[i];

                                b >>= i;
                                k -= i;

                                i = Index;
                                t = Table;
                                if (i + j > 258 + (t & 0x1f) + ((t >> 5) & 0x1f) || c == 16 && i < 1)
                                {
                                    Blens = null;
                                    _mode = InflateBlockMode.BAD;
                                    Codec.Message = "invalid bit length repeat";
                                    r = ZlibConstants.ZDataError;

                                    Bitb = b;
                                    Bitk = k;
                                    Codec.AvailableBytesIn = n;
                                    Codec.TotalBytesIn += p - Codec.NextIn;
                                    Codec.NextIn = p;
                                    WriteAt = q;
                                    return Flush(r);
                                }

                                c = c == 16 ? Blens[i - 1] : 0;
                                do
                                {
                                    Blens[i++] = c;
                                } while (--j != 0);

                                Index = i;
                            }
                        }

                        Tb[0] = -1;
                    {
                        int[] bl = {9};
                        int[] bd = {6};
                        var tl = new int[1];
                        var td = new int[1];

                        t = Table;
                        t = Inftree.Inflate_trees_dynamic(257 + (t & 0x1f), 1 + ((t >> 5) & 0x1f), Blens, bl, bd, tl,
                            td,
                            Hufts, Codec);

                        if (t != ZlibConstants.ZOk)
                        {
                            if (t == ZlibConstants.ZDataError)
                            {
                                Blens = null;
                                _mode = InflateBlockMode.BAD;
                            }

                            r = t;

                            Bitb = b;
                            Bitk = k;
                            Codec.AvailableBytesIn = n;
                            Codec.TotalBytesIn += p - Codec.NextIn;
                            Codec.NextIn = p;
                            WriteAt = q;
                            return Flush(r);
                        }

                        Codes.Init(bl[0], bd[0], Hufts, tl[0], Hufts, td[0]);
                    }
                        _mode = InflateBlockMode.CODES;
                        goto case InflateBlockMode.CODES;

                    case InflateBlockMode.CODES:
                        Bitb = b;
                        Bitk = k;
                        Codec.AvailableBytesIn = n;
                        Codec.TotalBytesIn += p - Codec.NextIn;
                        Codec.NextIn = p;
                        WriteAt = q;

                        r = Codes.Process(this, r);
                        if (r != ZlibConstants.ZStreamEnd) return Flush(r);

                        r = ZlibConstants.ZOk;
                        p = Codec.NextIn;
                        n = Codec.AvailableBytesIn;
                        b = Bitb;
                        k = Bitk;
                        q = WriteAt;
                        m = q < ReadAt ? ReadAt - q - 1 : End - q;

                        if (Last == 0)
                        {
                            _mode = InflateBlockMode.TYPE;
                            break;
                        }

                        _mode = InflateBlockMode.DRY;
                        goto case InflateBlockMode.DRY;

                    case InflateBlockMode.DRY:
                        WriteAt = q;
                        r = Flush(r);
                        q = WriteAt;

                        if (ReadAt != WriteAt)
                        {
                            Bitb = b;
                            Bitk = k;
                            Codec.AvailableBytesIn = n;
                            Codec.TotalBytesIn += p - Codec.NextIn;
                            Codec.NextIn = p;
                            WriteAt = q;
                            return Flush(r);
                        }

                        _mode = InflateBlockMode.DONE;
                        goto case InflateBlockMode.DONE;

                    case InflateBlockMode.DONE:
                        r = ZlibConstants.ZStreamEnd;
                        Bitb = b;
                        Bitk = k;
                        Codec.AvailableBytesIn = n;
                        Codec.TotalBytesIn += p - Codec.NextIn;
                        Codec.NextIn = p;
                        WriteAt = q;
                        return Flush(r);

                    case InflateBlockMode.BAD:
                        r = ZlibConstants.ZDataError;

                        Bitb = b;
                        Bitk = k;
                        Codec.AvailableBytesIn = n;
                        Codec.TotalBytesIn += p - Codec.NextIn;
                        Codec.NextIn = p;
                        WriteAt = q;
                        return Flush(r);

                    default:
                        r = ZlibConstants.ZStreamError;

                        Bitb = b;
                        Bitk = k;
                        Codec.AvailableBytesIn = n;
                        Codec.TotalBytesIn += p - Codec.NextIn;
                        Codec.NextIn = p;
                        WriteAt = q;
                        return Flush(r);
                }
        }

        internal uint Reset()
        {
            var oldCheck = Check;
            _mode = InflateBlockMode.TYPE;
            Bitk = 0;
            Bitb = 0;
            ReadAt = WriteAt = 0;

            if (Checkfn != null)
                Codec._Adler32 = Check = Adler.Adler32(0, null, 0, 0);
            return oldCheck;
        }

        internal void SetDictionary(byte[] d, int start, int n)
        {
            Array.Copy(d, start, Window, 0, n);
            ReadAt = WriteAt = n;
        }

        internal int SyncPoint()
        {
            return _mode == InflateBlockMode.LENS ? 1 : 0;
        }

        private enum InflateBlockMode
        {
            TYPE = 0, // get type bits (3, including end bit)
            LENS = 1, // get lengths for stored
            STORED = 2, // processing stored block
            TABLE = 3, // get table lengths
            BTREE = 4, // get bit lengths tree for a dynamic block
            DTREE = 5, // get length, distance trees for a dynamic block
            CODES = 6, // processing fixed or dynamic block
            DRY = 7, // output remaining window bytes
            DONE = 8, // finished last block, done
            BAD = 9 // ot a data error--stuck here
        }
    }

    internal sealed class InflateCodes
    {
        private const int BADCODE = 9;
        private const int COPY = 5;
        private const int DIST = 3;
        private const int DISTEXT = 4;
        private const int END = 8;
        private const int LEN = 1;
        private const int LENEXT = 2;
        private const int LIT = 6;
        private const int START = 0;
        private const int WASH = 7;
        internal int bitsToGet;
        internal byte dbits;
        internal int dist;
        internal int[] dtree;
        internal int dtree_index;
        internal byte lbits;
        internal int len;
        internal int lit;
        internal int[] ltree;
        internal int ltree_index;
        internal int mode;
        internal int need;
        internal int[] tree;
        internal int tree_index;

        internal int InflateFast(int bl, int bd, int[] tl, int tlIndex, int[] td, int tdIndex, InflateBlocks s,
            ZlibCodec z)
        {
            int c;

            var p = z.NextIn;
            var n = z.AvailableBytesIn;
            var b = s.Bitb;
            var k = s.Bitk;
            var q = s.WriteAt;
            var m = q < s.ReadAt ? s.ReadAt - q - 1 : s.End - q;

            var ml = InternalInflateConstants.InflateMask[bl];
            var md = InternalInflateConstants.InflateMask[bd];

            do
            {
                while (k < 20)
                {
                    n--;
                    b |= (z.InputBuffer[p++] & 0xff) << k;
                    k += 8;
                }

                var t = b & ml;
                var tp = tl;
                var tpIndex = tlIndex;
                var tpIndexT3 = (tpIndex + t) * 3;
                int e;
                if ((e = tp[tpIndexT3]) == 0)
                {
                    b >>= tp[tpIndexT3 + 1];
                    k -= tp[tpIndexT3 + 1];

                    s.Window[q++] = (byte) tp[tpIndexT3 + 2];
                    m--;
                    continue;
                }

                do
                {
                    b >>= tp[tpIndexT3 + 1];
                    k -= tp[tpIndexT3 + 1];

                    if ((e & 16) != 0)
                    {
                        e &= 15;
                        c = tp[tpIndexT3 + 2] + (b & InternalInflateConstants.InflateMask[e]);

                        b >>= e;
                        k -= e;

                        while (k < 15)
                        {
                            n--;
                            b |= (z.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        t = b & md;
                        tp = td;
                        tpIndex = tdIndex;
                        tpIndexT3 = (tpIndex + t) * 3;
                        e = tp[tpIndexT3];

                        do
                        {
                            b >>= tp[tpIndexT3 + 1];
                            k -= tp[tpIndexT3 + 1];

                            if ((e & 16) != 0)
                            {
                                e &= 15;
                                while (k < e)
                                {
                                    n--;
                                    b |= (z.InputBuffer[p++] & 0xff) << k;
                                    k += 8;
                                }

                                var d = tp[tpIndexT3 + 2] + (b & InternalInflateConstants.InflateMask[e]);

                                b >>= e;
                                k -= e;

                                m -= c;
                                int r;
                                if (q >= d)
                                {
                                    r = q - d;
                                    if (q - r > 0 && 2 > q - r)
                                    {
                                        s.Window[q++] = s.Window[r++];
                                        s.Window[q++] = s.Window[r++];
                                        c -= 2;
                                    }
                                    else
                                    {
                                        Array.Copy(s.Window, r, s.Window, q, 2);
                                        q += 2;
                                        r += 2;
                                        c -= 2;
                                    }
                                }
                                else
                                {
                                    r = q - d;
                                    do
                                    {
                                        r += s.End;
                                    } while (r < 0);

                                    e = s.End - r;
                                    if (c > e)
                                    {
                                        c -= e;
                                        if (q - r > 0 && e > q - r)
                                        {
                                            do
                                            {
                                                s.Window[q++] = s.Window[r++];
                                            } while (--e != 0);
                                        }
                                        else
                                        {
                                            Array.Copy(s.Window, r, s.Window, q, e);
                                            q += e;
                                        }

                                        r = 0;
                                    }
                                }

                                if (q - r > 0 && c > q - r)
                                {
                                    do
                                    {
                                        s.Window[q++] = s.Window[r++];
                                    } while (--c != 0);
                                }
                                else
                                {
                                    Array.Copy(s.Window, r, s.Window, q, c);
                                    q += c;
                                }

                                break;
                            }

                            if ((e & 64) == 0)
                            {
                                t += tp[tpIndexT3 + 2];
                                t += b & InternalInflateConstants.InflateMask[e];
                                tpIndexT3 = (tpIndex + t) * 3;
                                e = tp[tpIndexT3];
                            }
                            else
                            {
                                z.Message = "invalid distance code";

                                c = z.AvailableBytesIn - n;
                                c = k >> 3 < c ? k >> 3 : c;
                                n += c;
                                p -= c;
                                k -= c << 3;

                                s.Bitb = b;
                                s.Bitk = k;
                                z.AvailableBytesIn = n;
                                z.TotalBytesIn += p - z.NextIn;
                                z.NextIn = p;
                                s.WriteAt = q;

                                return ZlibConstants.ZDataError;
                            }
                        } while (true);

                        break;
                    }

                    if ((e & 64) == 0)
                    {
                        t += tp[tpIndexT3 + 2];
                        t += b & InternalInflateConstants.InflateMask[e];
                        tpIndexT3 = (tpIndex + t) * 3;
                        if ((e = tp[tpIndexT3]) != 0) continue;

                        b >>= tp[tpIndexT3 + 1];
                        k -= tp[tpIndexT3 + 1];
                        s.Window[q++] = (byte) tp[tpIndexT3 + 2];
                        m--;
                        break;
                    }

                    if ((e & 32) != 0)
                    {
                        c = z.AvailableBytesIn - n;
                        c = k >> 3 < c ? k >> 3 : c;
                        n += c;
                        p -= c;
                        k -= c << 3;

                        s.Bitb = b;
                        s.Bitk = k;
                        z.AvailableBytesIn = n;
                        z.TotalBytesIn += p - z.NextIn;
                        z.NextIn = p;
                        s.WriteAt = q;

                        return ZlibConstants.ZStreamEnd;
                    }

                    z.Message = "invalid literal/length code";

                    c = z.AvailableBytesIn - n;
                    c = k >> 3 < c ? k >> 3 : c;
                    n += c;
                    p -= c;
                    k -= c << 3;

                    s.Bitb = b;
                    s.Bitk = k;
                    z.AvailableBytesIn = n;
                    z.TotalBytesIn += p - z.NextIn;
                    z.NextIn = p;
                    s.WriteAt = q;

                    return ZlibConstants.ZDataError;
                } while (true);
            } while (m >= 258 && n >= 10);

            c = z.AvailableBytesIn - n;
            c = k >> 3 < c ? k >> 3 : c;
            n += c;
            p -= c;
            k -= c << 3;

            s.Bitb = b;
            s.Bitk = k;
            z.AvailableBytesIn = n;
            z.TotalBytesIn += p - z.NextIn;
            z.NextIn = p;
            s.WriteAt = q;

            return ZlibConstants.ZOk;
        }

        internal void Init(int bl, int bd, int[] tl, int tlIndex, int[] td, int tdIndex)
        {
            mode = START;
            lbits = (byte) bl;
            dbits = (byte) bd;
            ltree = tl;
            ltree_index = tlIndex;
            dtree = td;
            dtree_index = tdIndex;
            tree = null;
        }

        internal int Process(InflateBlocks blocks, int r)
        {
            int j;
            int tindex;
            int e;

            var z = blocks.Codec;

            var p = z.NextIn;
            var n = z.AvailableBytesIn;
            var b = blocks.Bitb;
            var k = blocks.Bitk;
            var q = blocks.WriteAt;
            var m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;

            while (true)
                switch (mode)
                {
                    case START:
                        if (m >= 258 && n >= 10)
                        {
                            blocks.Bitb = b;
                            blocks.Bitk = k;
                            z.AvailableBytesIn = n;
                            z.TotalBytesIn += p - z.NextIn;
                            z.NextIn = p;
                            blocks.WriteAt = q;
                            r = InflateFast(lbits, dbits, ltree, ltree_index, dtree, dtree_index, blocks, z);

                            p = z.NextIn;
                            n = z.AvailableBytesIn;
                            b = blocks.Bitb;
                            k = blocks.Bitk;
                            q = blocks.WriteAt;
                            m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;

                            if (r != ZlibConstants.ZOk)
                            {
                                mode = r == ZlibConstants.ZStreamEnd ? WASH : BADCODE;
                                break;
                            }
                        }

                        need = lbits;
                        tree = ltree;
                        tree_index = ltree_index;

                        mode = LEN;
                        goto case LEN;

                    case LEN:
                        j = need;

                        while (k < j)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                blocks.Bitb = b;
                                blocks.Bitk = k;
                                z.AvailableBytesIn = n;
                                z.TotalBytesIn += p - z.NextIn;
                                z.NextIn = p;
                                blocks.WriteAt = q;
                                return blocks.Flush(r);
                            }

                            n--;
                            b |= (z.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        tindex = (tree_index + (b & InternalInflateConstants.InflateMask[j])) * 3;

                        b >>= tree[tindex + 1];
                        k -= tree[tindex + 1];

                        e = tree[tindex];

                        if (e == 0)
                        {
                            lit = tree[tindex + 2];
                            mode = LIT;
                            break;
                        }

                        if ((e & 16) != 0)
                        {
                            bitsToGet = e & 15;
                            len = tree[tindex + 2];
                            mode = LENEXT;
                            break;
                        }

                        if ((e & 64) == 0)
                        {
                            need = e;
                            tree_index = tindex / 3 + tree[tindex + 2];
                            break;
                        }

                        if ((e & 32) != 0)
                        {
                            mode = WASH;
                            break;
                        }

                        mode = BADCODE;
                        z.Message = "invalid literal/length code";
                        r = ZlibConstants.ZDataError;

                        blocks.Bitb = b;
                        blocks.Bitk = k;
                        z.AvailableBytesIn = n;
                        z.TotalBytesIn += p - z.NextIn;
                        z.NextIn = p;
                        blocks.WriteAt = q;
                        return blocks.Flush(r);

                    case LENEXT:
                        j = bitsToGet;

                        while (k < j)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                blocks.Bitb = b;
                                blocks.Bitk = k;
                                z.AvailableBytesIn = n;
                                z.TotalBytesIn += p - z.NextIn;
                                z.NextIn = p;
                                blocks.WriteAt = q;
                                return blocks.Flush(r);
                            }

                            n--;
                            b |= (z.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        len += b & InternalInflateConstants.InflateMask[j];

                        b >>= j;
                        k -= j;

                        need = dbits;
                        tree = dtree;
                        tree_index = dtree_index;
                        mode = DIST;
                        goto case DIST;

                    case DIST:
                        j = need;

                        while (k < j)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                blocks.Bitb = b;
                                blocks.Bitk = k;
                                z.AvailableBytesIn = n;
                                z.TotalBytesIn += p - z.NextIn;
                                z.NextIn = p;
                                blocks.WriteAt = q;
                                return blocks.Flush(r);
                            }

                            n--;
                            b |= (z.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        tindex = (tree_index + (b & InternalInflateConstants.InflateMask[j])) * 3;

                        b >>= tree[tindex + 1];
                        k -= tree[tindex + 1];

                        e = tree[tindex];
                        if ((e & 0x10) != 0)
                        {
                            bitsToGet = e & 15;
                            dist = tree[tindex + 2];
                            mode = DISTEXT;
                            break;
                        }

                        if ((e & 64) == 0)
                        {
                            need = e;
                            tree_index = tindex / 3 + tree[tindex + 2];
                            break;
                        }

                        mode = BADCODE;
                        z.Message = "invalid distance code";
                        r = ZlibConstants.ZDataError;

                        blocks.Bitb = b;
                        blocks.Bitk = k;
                        z.AvailableBytesIn = n;
                        z.TotalBytesIn += p - z.NextIn;
                        z.NextIn = p;
                        blocks.WriteAt = q;
                        return blocks.Flush(r);

                    case DISTEXT:
                        j = bitsToGet;

                        while (k < j)
                        {
                            if (n != 0)
                            {
                                r = ZlibConstants.ZOk;
                            }
                            else
                            {
                                blocks.Bitb = b;
                                blocks.Bitk = k;
                                z.AvailableBytesIn = n;
                                z.TotalBytesIn += p - z.NextIn;
                                z.NextIn = p;
                                blocks.WriteAt = q;
                                return blocks.Flush(r);
                            }

                            n--;
                            b |= (z.InputBuffer[p++] & 0xff) << k;
                            k += 8;
                        }

                        dist += b & InternalInflateConstants.InflateMask[j];

                        b >>= j;
                        k -= j;

                        mode = COPY;
                        goto case COPY;

                    case COPY:
                        var f = q - dist;
                        while (f < 0)
                            f += blocks.End;
                        while (len != 0)
                        {
                            if (m == 0)
                            {
                                if (q == blocks.End && blocks.ReadAt != 0)
                                {
                                    q = 0;
                                    m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;
                                }

                                if (m == 0)
                                {
                                    blocks.WriteAt = q;
                                    r = blocks.Flush(r);
                                    q = blocks.WriteAt;
                                    m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;

                                    if (q == blocks.End && blocks.ReadAt != 0)
                                    {
                                        q = 0;
                                        m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;
                                    }

                                    if (m == 0)
                                    {
                                        blocks.Bitb = b;
                                        blocks.Bitk = k;
                                        z.AvailableBytesIn = n;
                                        z.TotalBytesIn += p - z.NextIn;
                                        z.NextIn = p;
                                        blocks.WriteAt = q;
                                        return blocks.Flush(r);
                                    }
                                }
                            }

                            blocks.Window[q++] = blocks.Window[f++];
                            m--;

                            if (f == blocks.End)
                                f = 0;
                            len--;
                        }

                        mode = START;
                        break;

                    case LIT:
                        if (m == 0)
                        {
                            if (q == blocks.End && blocks.ReadAt != 0)
                            {
                                q = 0;
                                m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;
                            }

                            if (m == 0)
                            {
                                blocks.WriteAt = q;
                                r = blocks.Flush(r);
                                q = blocks.WriteAt;
                                m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;

                                if (q == blocks.End && blocks.ReadAt != 0)
                                {
                                    q = 0;
                                    m = q < blocks.ReadAt ? blocks.ReadAt - q - 1 : blocks.End - q;
                                }

                                if (m == 0)
                                {
                                    blocks.Bitb = b;
                                    blocks.Bitk = k;
                                    z.AvailableBytesIn = n;
                                    z.TotalBytesIn += p - z.NextIn;
                                    z.NextIn = p;
                                    blocks.WriteAt = q;
                                    return blocks.Flush(r);
                                }
                            }
                        }

                        r = ZlibConstants.ZOk;

                        blocks.Window[q++] = (byte) lit;
                        m--;

                        mode = START;
                        break;

                    case WASH:
                        if (k > 7)
                        {
                            k -= 8;
                            n++;
                            p--;
                        }

                        blocks.WriteAt = q;
                        r = blocks.Flush(r);
                        q = blocks.WriteAt;

                        if (blocks.ReadAt != blocks.WriteAt)
                        {
                            blocks.Bitb = b;
                            blocks.Bitk = k;
                            z.AvailableBytesIn = n;
                            z.TotalBytesIn += p - z.NextIn;
                            z.NextIn = p;
                            blocks.WriteAt = q;
                            return blocks.Flush(r);
                        }

                        mode = END;
                        goto case END;

                    case END:
                        r = ZlibConstants.ZStreamEnd;
                        blocks.Bitb = b;
                        blocks.Bitk = k;
                        z.AvailableBytesIn = n;
                        z.TotalBytesIn += p - z.NextIn;
                        z.NextIn = p;
                        blocks.WriteAt = q;
                        return blocks.Flush(r);

                    case BADCODE:

                        r = ZlibConstants.ZDataError;

                        blocks.Bitb = b;
                        blocks.Bitk = k;
                        z.AvailableBytesIn = n;
                        z.TotalBytesIn += p - z.NextIn;
                        z.NextIn = p;
                        blocks.WriteAt = q;
                        return blocks.Flush(r);

                    default:
                        r = ZlibConstants.ZStreamError;

                        blocks.Bitb = b;
                        blocks.Bitk = k;
                        z.AvailableBytesIn = n;
                        z.TotalBytesIn += p - z.NextIn;
                        z.NextIn = p;
                        blocks.WriteAt = q;
                        return blocks.Flush(r);
                }
        }
    }

    internal sealed class InflateManager
    {
        private const int PresetDict = 0x20;

        private const int ZDeflated = 8;

        private static readonly byte[] Mark = {0, 0, 0xff, 0xff};

        private InflateManagerMode _mode;
        internal InflateBlocks Blocks;

        internal ZlibCodec Codec;
        internal uint ComputedCheck;
        internal uint ExpectedCheck;
        internal int Marker;
        internal int Method;
        internal int Wbits;

        public InflateManager()
        {
        }

        public InflateManager(bool expectRfc1950HeaderBytes)
        {
            HandleRfc1950HeaderBytes = expectRfc1950HeaderBytes;
        }

        internal bool HandleRfc1950HeaderBytes { get; set; } = true;

        internal int End()
        {
            Blocks?.Free();
            Blocks = null;
            return ZlibConstants.ZOk;
        }

        internal int Inflate()
        {
            if (Codec.InputBuffer == null)
                throw new ZlibException("InputBuffer is null. ");

            const int f = ZlibConstants.ZOk;
            var r = ZlibConstants.ZBufError;

            while (true)
                switch (_mode)
                {
                    case InflateManagerMode.Method:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        if (((Method = Codec.InputBuffer[Codec.NextIn++]) & 0xf) != ZDeflated)
                        {
                            _mode = InflateManagerMode.Bad;
                            Codec.Message = $"unknown compression method (0x{Method:X2})";
                            Marker = 5;
                            break;
                        }

                        if ((Method >> 4) + 8 > Wbits)
                        {
                            _mode = InflateManagerMode.Bad;
                            Codec.Message = $"invalid window size ({(Method >> 4) + 8})";
                            Marker = 5;
                            break;
                        }

                        _mode = InflateManagerMode.Flag;
                        break;

                    case InflateManagerMode.Flag:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        var b = Codec.InputBuffer[Codec.NextIn++] & 0xff;

                        if (((Method << 8) + b) % 31 != 0)
                        {
                            _mode = InflateManagerMode.Bad;
                            Codec.Message = "incorrect header check";
                            Marker = 5;
                            break;
                        }

                        _mode = (b & PresetDict) == 0
                            ? InflateManagerMode.Blocks
                            : InflateManagerMode.Dict4;
                        break;

                    case InflateManagerMode.Dict4:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck = (uint) ((Codec.InputBuffer[Codec.NextIn++] << 24) & 0xff000000);
                        _mode = InflateManagerMode.Dict3;
                        break;

                    case InflateManagerMode.Dict3:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck += (uint) ((Codec.InputBuffer[Codec.NextIn++] << 16) & 0x00ff0000);
                        _mode = InflateManagerMode.Dict2;
                        break;

                    case InflateManagerMode.Dict2:

                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck += (uint) ((Codec.InputBuffer[Codec.NextIn++] << 8) & 0x0000ff00);
                        _mode = InflateManagerMode.Dict1;
                        break;

                    case InflateManagerMode.Dict1:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck += (uint) (Codec.InputBuffer[Codec.NextIn++] & 0x000000ff);
                        Codec._Adler32 = ExpectedCheck;
                        _mode = InflateManagerMode.Dict0;
                        return ZlibConstants.ZNeedDict;

                    case InflateManagerMode.Dict0:
                        _mode = InflateManagerMode.Bad;
                        Codec.Message = "need dictionary";
                        Marker = 0;
                        return ZlibConstants.ZStreamError;

                    case InflateManagerMode.Blocks:
                        r = Blocks.Process(r);
                        if (r == ZlibConstants.ZDataError)
                        {
                            _mode = InflateManagerMode.Bad;
                            Marker = 0;
                            break;
                        }

                        if (r == ZlibConstants.ZOk)
                            r = f;

                        if (r != ZlibConstants.ZStreamEnd)
                            return r;

                        r = f;
                        ComputedCheck = Blocks.Reset();
                        if (!HandleRfc1950HeaderBytes)
                        {
                            _mode = InflateManagerMode.Done;
                            return ZlibConstants.ZStreamEnd;
                        }

                        _mode = InflateManagerMode.Check4;
                        break;

                    case InflateManagerMode.Check4:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck = (uint) ((Codec.InputBuffer[Codec.NextIn++] << 24) & 0xff000000);
                        _mode = InflateManagerMode.Check3;
                        break;

                    case InflateManagerMode.Check3:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck += (uint) ((Codec.InputBuffer[Codec.NextIn++] << 16) & 0x00ff0000);
                        _mode = InflateManagerMode.Check2;
                        break;

                    case InflateManagerMode.Check2:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck += (uint) ((Codec.InputBuffer[Codec.NextIn++] << 8) & 0x0000ff00);
                        _mode = InflateManagerMode.Check1;
                        break;

                    case InflateManagerMode.Check1:
                        if (Codec.AvailableBytesIn == 0)
                            return r;

                        r = f;
                        Codec.AvailableBytesIn--;
                        Codec.TotalBytesIn++;
                        ExpectedCheck += (uint) (Codec.InputBuffer[Codec.NextIn++] & 0x000000ff);
                        if (ComputedCheck != ExpectedCheck)
                        {
                            _mode = InflateManagerMode.Bad;
                            Codec.Message = "incorrect data check";
                            Marker = 5;
                            break;
                        }

                        _mode = InflateManagerMode.Done;
                        return ZlibConstants.ZStreamEnd;

                    case InflateManagerMode.Done:
                        return ZlibConstants.ZStreamEnd;

                    case InflateManagerMode.Bad:
                        throw new ZlibException($"Bad state ({Codec.Message})");

                    default:
                        throw new ZlibException("Stream error.");
                }
        }

        internal int Initialize(ZlibCodec codec, int w)
        {
            Codec = codec;
            Codec.Message = null;
            Blocks = null;

            if (w < 8 || w > 15)
            {
                End();
                throw new ZlibException("Bad window size.");
            }

            Wbits = w;

            Blocks = new InflateBlocks(codec,
                HandleRfc1950HeaderBytes ? this : null,
                1 << w);

            Reset();
            return ZlibConstants.ZOk;
        }

        internal int Reset()
        {
            Codec.TotalBytesIn = Codec.TotalBytesOut = 0;
            Codec.Message = null;
            _mode = HandleRfc1950HeaderBytes ? InflateManagerMode.Method : InflateManagerMode.Blocks;
            Blocks.Reset();
            return ZlibConstants.ZOk;
        }

        internal int SetDictionary(byte[] dictionary)
        {
            var index = 0;
            var length = dictionary.Length;
            if (_mode != InflateManagerMode.Dict0)
                throw new ZlibException("Stream error.");

            if (Adler.Adler32(1, dictionary, 0, dictionary.Length) != Codec._Adler32)
                return ZlibConstants.ZDataError;

            Codec._Adler32 = Adler.Adler32(0, null, 0, 0);

            if (length >= 1 << Wbits)
            {
                length = (1 << Wbits) - 1;
                index = dictionary.Length - length;
            }

            Blocks.SetDictionary(dictionary, index, length);
            _mode = InflateManagerMode.Blocks;
            return ZlibConstants.ZOk;
        }

        internal int Sync()
        {
            int n;

            if (_mode != InflateManagerMode.Bad)
            {
                _mode = InflateManagerMode.Bad;
                Marker = 0;
            }

            if ((n = Codec.AvailableBytesIn) == 0)
                return ZlibConstants.ZBufError;

            var p = Codec.NextIn;
            var m = Marker;

            while (n != 0 && m < 4)
            {
                if (Codec.InputBuffer[p] == Mark[m]) m++;
                else if (Codec.InputBuffer[p] != 0) m = 0;
                else m = 4 - m;
                p++;
                n--;
            }

            Codec.TotalBytesIn += p - Codec.NextIn;
            Codec.NextIn = p;
            Codec.AvailableBytesIn = n;
            Marker = m;

            if (m != 4) return ZlibConstants.ZDataError;

            var r = Codec.TotalBytesIn;
            var w = Codec.TotalBytesOut;
            Reset();
            Codec.TotalBytesIn = r;
            Codec.TotalBytesOut = w;
            _mode = InflateManagerMode.Blocks;
            return ZlibConstants.ZOk;
        }

        internal int SyncPoint()
        {
            return Blocks.SyncPoint();
        }

        private enum InflateManagerMode
        {
            Method = 0,
            Flag = 1,
            Dict4 = 2,
            Dict3 = 3,
            Dict2 = 4,
            Dict1 = 5,
            Dict0 = 6,
            Blocks = 7,
            Check4 = 8,
            Check3 = 9,
            Check2 = 10,
            Check1 = 11,
            Done = 12,
            Bad = 13
        }
    }
}