using System;
using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using DotNetty.Transport.Channels;

namespace BrawlStars.Protocol.Messages.Server
{
    public class OwnHomeDataMessage : PiranhaMessage
    {
        public OwnHomeDataMessage(Device device) : base(device)
        {
            Id = 24101;
            device.CurrentState = Device.State.Home;
            Device.LastVisitHome = DateTime.UtcNow;
        }

        public override void Encode()
        {
            Writer.WriteVInt(2020007);
            Writer.WriteVInt(75158);
            Writer.WriteVInt(Resources.Trophies);

            Writer.WriteVInt(99999);
            Writer.WriteVInt(122);
            Writer.WriteVInt(100); //reward for trophy road

            Writer.WriteVInt(1262469); // starting level (exp points)
            Writer.WriteVInt(28);
            Writer.WriteVInt(Resources.ProfileIcon); // player icon ID
            Writer.WriteVInt(43);
            Writer.WriteVInt(Resources.NameColor); // player name color ID

            Writer.WriteVInt(9);
            Writer.WriteVInt(0);
            Writer.WriteVInt(2);
            Writer.WriteVInt(3);
            Writer.WriteVInt(5);
            Writer.WriteVInt(6);
            Writer.WriteVInt(7);
            Writer.WriteVInt(8);
            Writer.WriteVInt(9);
            Writer.WriteVInt(10);
            Writer.WriteVInt(3);
            Writer.WriteVInt(29);
            Writer.WriteVInt(14);
            Writer.WriteVInt(29);
            Writer.WriteVInt(Resources.Skin);
            Writer.WriteVInt(29);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteBoolean(false); // "token limit reached message" if value is 1
            Writer.WriteVInt(1);
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(248791);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(200);
            Writer.WriteVInt(200);
            Writer.WriteVInt(5);
            Writer.WriteVInt(93);
            Writer.WriteVInt(206);
            Writer.WriteVInt(456);
            Writer.WriteVInt(1001);
            Writer.WriteVInt(2264);
            Writer.WriteVInt(8);
            Writer.WriteVInt(2);
            Writer.WriteVInt(2);
            Writer.WriteVInt(2);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(200); //tokens in menu
            Writer.WriteVInt(1140);
            Writer.WriteBoolean(true); // tickets enabled
            Writer.WriteVInt(0);
            Writer.WriteVInt(Resources.Tickets); // tickets number
            Writer.WriteVInt(-21);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Resources.Brawler);
            Writer.WriteScString(Resources.Region);
            Writer.WriteVInt(-1);
            Writer.WriteVInt(-133169153);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(2019053);
            Writer.WriteVInt(100);
            Writer.WriteVInt(10);

            Writer.WriteVInt(30); // shop big box price
            Writer.WriteVInt(3);
            Writer.WriteVInt(80); // shop mega box price
            Writer.WriteVInt(10);
            Writer.WriteVInt(50); // shop token doubler price
            Writer.WriteVInt(1000); // shop token doubler amount

            Writer.WriteVInt(500);
            Writer.WriteVInt(50);
            Writer.WriteVInt(999900);
            Writer.WriteVInt(6);
            Writer.WriteVInt(0);
            Writer.WriteVInt(30);
            Writer.WriteVInt(80);
            Writer.WriteVInt(170);
            Writer.WriteVInt(350);
            Writer.WriteVInt(0);
            Writer.WriteVInt(15);
            Writer.WriteVInt(1);
            Writer.WriteVInt(2);
            Writer.WriteVInt(3);
            Writer.WriteVInt(4);
            Writer.WriteVInt(5);
            Writer.WriteVInt(6);
            Writer.WriteVInt(7);
            Writer.WriteVInt(8);
            Writer.WriteVInt(9);
            Writer.WriteVInt(10);
            Writer.WriteVInt(20);
            Writer.WriteVInt(21);
            Writer.WriteVInt(22);
            Writer.WriteVInt(23);
            Writer.WriteVInt(24);

            Writer.WriteVInt(9); // slots count

            Writer.WriteVInt(-133000102); // map slot starts here (i think)
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(7); // game mode slot map id

            Writer.WriteVInt(3); //0 or 1 = new event, 2 = Star Token, 3 = Default
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0); // // map slot ends here


            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(2);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(32); //Showdown Solo

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(17);

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(4);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(0);

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(5);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(38); //Showdown Duo

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(6);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(24);

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(7);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(202);

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(8);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(97);

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);

            Writer.WriteVInt(-133000102);
            Writer.WriteVInt(9);
            Writer.WriteVInt(0);
            Writer.WriteVInt(75992);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);

            Writer.WriteVInt(167);

            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);



            Writer.WriteVInt(0);
            Writer.WriteVInt(8);
            Writer.WriteVInt(20);
            Writer.WriteVInt(35);
            Writer.WriteVInt(75);

            Writer.WriteVInt(140);
            Writer.WriteVInt(290);
            Writer.WriteVInt(480);
            Writer.WriteVInt(800);
            Writer.WriteVInt(1250);

            Writer.WriteVInt(8);
            Writer.WriteVInt(1);
            Writer.WriteVInt(2);
            Writer.WriteVInt(3);
            Writer.WriteVInt(4);
            Writer.WriteVInt(5);
            Writer.WriteVInt(10);
            Writer.WriteVInt(15);
            Writer.WriteVInt(20);
            Writer.WriteVInt(3);
            Writer.WriteVInt(10);

            Writer.WriteVInt(30);
            Writer.WriteVInt(80);

            Writer.WriteVInt(3);
            Writer.WriteVInt(6);
            Writer.WriteVInt(20);
            Writer.WriteVInt(60);

            Writer.WriteVInt(4);

            Writer.WriteVInt(20); // first coin pack price
            Writer.WriteVInt(50); // second coin pack price
            Writer.WriteVInt(140); // third coin pack price
            Writer.WriteVInt(280); // fourth coin pack price

            Writer.WriteVInt(4);

            Writer.WriteVInt(150); // first coin pack amount
            Writer.WriteVInt(400); // second coin pack amount 
            Writer.WriteVInt(1200); // third  coin pack amount
            Writer.WriteVInt(2600); // fourth  coin pack amount         

            Writer.WriteVInt(2);
            Writer.WriteVInt(200);
            Writer.WriteVInt(20);
            Writer.WriteVInt(8640);
            Writer.WriteVInt(10);
            Writer.WriteVInt(5);
            Writer.WriteVInt(6);
            Writer.WriteVInt(50);
            Writer.WriteVInt(604800);
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(14);
            Writer.WriteVInt(0);
            Writer.WriteVInt(3193);
            Writer.WriteVInt(-8);
            Writer.WriteInt(0);
            Writer.WriteInt(1); //Low Id
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString(Resources.Name);
            Writer.WriteBoolean(true); // enter name skipped
            Writer.WriteScString(null);
            Writer.WriteScString(null);
            Writer.WriteVInt(8);

            Writer.WriteVInt(39);
            Writer.WriteScId(23, 0);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 4);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 8);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 12);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 16);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 20);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 24);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 28);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 32);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 36);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 40);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 44);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 48);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 52);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 56);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 60);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 64);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 68);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 72);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 95);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 100);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 105);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 110);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 115);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 120);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 125);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 130);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 177);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 182);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 188);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 194);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 200);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 206);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 218);
            Writer.WriteVInt(1);
            Writer.WriteScId(23, 236);
            Writer.WriteVInt(1);

            Writer.WriteScId(5, 1);
            Writer.WriteVInt(99999); // brawl box tokens (100 tokens = 1 brawl box)
            Writer.WriteScId(5, 8);
            Writer.WriteVInt(Resources.Gold); // gold
            Writer.WriteScId(5, 9);
            Writer.WriteVInt(99999); // big box tokens (10 tokens = 1 big box)
            Writer.WriteScId(5, 10);
            Writer.WriteVInt(99999); // star tokens

            Writer.WriteVInt(35); // brawlers count

            Writer.WriteScId(16, 0);
            Writer.WriteVInt(99999); // shelly trophies
            Writer.WriteScId(16, 1);
            Writer.WriteVInt(99999); // colt trophies
            Writer.WriteScId(16, 2);
            Writer.WriteVInt(99999); // bull trophies
            Writer.WriteScId(16, 3);
            Writer.WriteVInt(99999); // brock trophies
            Writer.WriteScId(16, 4);
            Writer.WriteVInt(99999); // rico trophies
            Writer.WriteScId(16, 5);
            Writer.WriteVInt(99999); // spike trophies
            Writer.WriteScId(16, 6);
            Writer.WriteVInt(99999); // barley trophies
            Writer.WriteScId(16, 7);
            Writer.WriteVInt(99999); // jessie trophies
            Writer.WriteScId(16, 8);
            Writer.WriteVInt(99999); // nita trophies
            Writer.WriteScId(16, 9);
            Writer.WriteVInt(99999); // dynamike trophies
            Writer.WriteScId(16, 10);
            Writer.WriteVInt(99999); // primo trophies
            Writer.WriteScId(16, 11);
            Writer.WriteVInt(99999); // mortis trophies
            Writer.WriteScId(16, 12);
            Writer.WriteVInt(99999); // crow trophies
            Writer.WriteScId(16, 13);
            Writer.WriteVInt(99999); // poco trophies
            Writer.WriteScId(16, 14);
            Writer.WriteVInt(99999); // bo trophies
            Writer.WriteScId(16, 15);
            Writer.WriteVInt(99999); // piper trophies
            Writer.WriteScId(16, 16);
            Writer.WriteVInt(99999); // pam trophies
            Writer.WriteScId(16, 17);
            Writer.WriteVInt(99999); // tara trophies
            Writer.WriteScId(16, 18);
            Writer.WriteVInt(99999); // darryl trophies
            Writer.WriteScId(16, 19);
            Writer.WriteVInt(99999); // penny trophies
            Writer.WriteScId(16, 20);
            Writer.WriteVInt(99999); // frank trophies
            Writer.WriteScId(16, 21);
            Writer.WriteVInt(99999); // gene trophies
            Writer.WriteScId(16, 22);
            Writer.WriteVInt(99999); // tick trophies
            Writer.WriteScId(16, 23);
            Writer.WriteVInt(99999); // leon trophies
            Writer.WriteScId(16, 24);
            Writer.WriteVInt(99999); // rosa trophies
            Writer.WriteScId(16, 25);
            Writer.WriteVInt(99999); // carl trophies
            Writer.WriteScId(16, 26);
            Writer.WriteVInt(99999); // bibi trophies
            Writer.WriteScId(16, 27);
            Writer.WriteVInt(99999); // 8bit trophies
            Writer.WriteScId(16, 28);
            Writer.WriteVInt(99999); // sandy trophies
            Writer.WriteScId(16, 29);
            Writer.WriteVInt(99999); // bea trophies
            Writer.WriteScId(16, 30);
            Writer.WriteVInt(99999); // emz trophies
            Writer.WriteScId(16, 31);
            Writer.WriteVInt(99999); // mr p trophies
            Writer.WriteScId(16, 32);
            Writer.WriteVInt(99999); // max trophies
            Writer.WriteScId(16, 34);
            Writer.WriteVInt(99999); // jacky trophies
            Writer.WriteScId(16, 37);
            Writer.WriteVInt(99999); // sprout trophies



            Writer.WriteVInt(35); // brawlers count

            Writer.WriteScId(16, 0);
            Writer.WriteVInt(99999); // shelly trophies for rank
            Writer.WriteScId(16, 1);
            Writer.WriteVInt(99999); // colt trophies for rank
            Writer.WriteScId(16, 2);
            Writer.WriteVInt(99999); // bull trophies for rank
            Writer.WriteScId(16, 3);
            Writer.WriteVInt(99999); // brock trophies for rank
            Writer.WriteScId(16, 4);
            Writer.WriteVInt(99999); // rico trophies for rank
            Writer.WriteScId(16, 5);
            Writer.WriteVInt(99999); // spike trophies for rank
            Writer.WriteScId(16, 6);
            Writer.WriteVInt(99999); // barley trophies for rank
            Writer.WriteScId(16, 7);
            Writer.WriteVInt(99999); // jessie trophies for rank
            Writer.WriteScId(16, 8);
            Writer.WriteVInt(99999); // nita trophies for rank
            Writer.WriteScId(16, 9);
            Writer.WriteVInt(99999); // dynamike trophies for rank
            Writer.WriteScId(16, 10);
            Writer.WriteVInt(99999); // primo trophies for rank
            Writer.WriteScId(16, 11);
            Writer.WriteVInt(99999); // mortis trophies for rank
            Writer.WriteScId(16, 12);
            Writer.WriteVInt(99999); // crow trophies for rank
            Writer.WriteScId(16, 13);
            Writer.WriteVInt(99999); // poco trophies for rank
            Writer.WriteScId(16, 14);
            Writer.WriteVInt(99999); // bo trophies for rank
            Writer.WriteScId(16, 15);
            Writer.WriteVInt(99999); // piper trophies for rank
            Writer.WriteScId(16, 16);
            Writer.WriteVInt(99999); // pam trophies for rank
            Writer.WriteScId(16, 17);
            Writer.WriteVInt(99999); // tara trophies for rank
            Writer.WriteScId(16, 18);
            Writer.WriteVInt(99999); // darryl trophies for rank
            Writer.WriteScId(16, 19);
            Writer.WriteVInt(99999); // penny trophies for rank
            Writer.WriteScId(16, 20);
            Writer.WriteVInt(99999); // frank trophies for rank
            Writer.WriteScId(16, 21);
            Writer.WriteVInt(99999); // gene trophies for rank
            Writer.WriteScId(16, 22);
            Writer.WriteVInt(99999); // tick trophies for rank
            Writer.WriteScId(16, 23);
            Writer.WriteVInt(99999); // leon trophies for rank
            Writer.WriteScId(16, 24);
            Writer.WriteVInt(99999); // rosa trophies for rank
            Writer.WriteScId(16, 25);
            Writer.WriteVInt(99999); // carl trophies for rank
            Writer.WriteScId(16, 26);
            Writer.WriteVInt(99999); // bibi trophies for rank
            Writer.WriteScId(16, 27);
            Writer.WriteVInt(99999); // 8bit trophies for rank
            Writer.WriteScId(16, 28);
            Writer.WriteVInt(99999); // sandy trophies for rank
            Writer.WriteScId(16, 29);
            Writer.WriteVInt(99999); // bea trophies for rank
            Writer.WriteScId(16, 30);
            Writer.WriteVInt(99999); // emz trophies for rank
            Writer.WriteScId(16, 31);
            Writer.WriteVInt(99999); // mr p trophies for rank
            Writer.WriteScId(16, 32);
            Writer.WriteVInt(99999); // max trophies for rank
            Writer.WriteScId(16, 34);
            Writer.WriteVInt(99999); // jacky trophies for rank
            Writer.WriteScId(16, 37);
            Writer.WriteVInt(99999); // sprout trophies for rank


            Writer.WriteVInt(0);

            Writer.WriteVInt(35); // brawlers count


            Writer.WriteScId(16, 0);
            Writer.WriteVInt(1440); // hmm what could this be?
            Writer.WriteScId(16, 1);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 2);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 3);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 4);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 5);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 6);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 7);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 8);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 9);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 10);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 11);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 12);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 13);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 14);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 15);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 16);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 17);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 18);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 19);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 20);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 21);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 22);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 23);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 24);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 25);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 26);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 27);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 28);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 29);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 30);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 31);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 32);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 34);
            Writer.WriteVInt(1440);
            Writer.WriteScId(16, 37);
            Writer.WriteVInt(1440);

            Writer.WriteVInt(35); // brawlers count

            Writer.WriteScId(16, 0);
            Writer.WriteVInt(8); // shelly power level (value shows in game +1, so value 8 = power 9)
            Writer.WriteScId(16, 1);
            Writer.WriteVInt(8); // colt power level
            Writer.WriteScId(16, 2);
            Writer.WriteVInt(8); // bull power level 
            Writer.WriteScId(16, 3);
            Writer.WriteVInt(8); // brock power level
            Writer.WriteScId(16, 4);
            Writer.WriteVInt(8); // rico power level
            Writer.WriteScId(16, 5);
            Writer.WriteVInt(8); // spike power level
            Writer.WriteScId(16, 6);
            Writer.WriteVInt(8); // barley power level
            Writer.WriteScId(16, 7);
            Writer.WriteVInt(8); // jessie power level
            Writer.WriteScId(16, 8);
            Writer.WriteVInt(8); // nita power level
            Writer.WriteScId(16, 9);
            Writer.WriteVInt(8); // dynamike power level
            Writer.WriteScId(16, 10);
            Writer.WriteVInt(8); // primo power level
            Writer.WriteScId(16, 11);
            Writer.WriteVInt(8); // mortis power level
            Writer.WriteScId(16, 12);
            Writer.WriteVInt(8); // crow power level
            Writer.WriteScId(16, 13);
            Writer.WriteVInt(8); // poco power level
            Writer.WriteScId(16, 14);
            Writer.WriteVInt(8); // bo power level
            Writer.WriteScId(16, 15);
            Writer.WriteVInt(8); // piper power level
            Writer.WriteScId(16, 16);
            Writer.WriteVInt(8); // pam power level
            Writer.WriteScId(16, 17);
            Writer.WriteVInt(8); // tara power level
            Writer.WriteScId(16, 18);
            Writer.WriteVInt(8); // darryl power level
            Writer.WriteScId(16, 19);
            Writer.WriteVInt(8); // peny power level
            Writer.WriteScId(16, 20);
            Writer.WriteVInt(8); // frank power level
            Writer.WriteScId(16, 21);
            Writer.WriteVInt(8); // gene power level
            Writer.WriteScId(16, 22);
            Writer.WriteVInt(8); // tick power level
            Writer.WriteScId(16, 23);
            Writer.WriteVInt(8); // leon power level
            Writer.WriteScId(16, 24);
            Writer.WriteVInt(8); // rosa power level
            Writer.WriteScId(16, 25);
            Writer.WriteVInt(8); // carl power level
            Writer.WriteScId(16, 26);
            Writer.WriteVInt(8); // bibi power level
            Writer.WriteScId(16, 27);
            Writer.WriteVInt(8); // 8bit power level
            Writer.WriteScId(16, 28);
            Writer.WriteVInt(8); // sandy power level
            Writer.WriteScId(16, 29);
            Writer.WriteVInt(8); // bea power level
            Writer.WriteScId(16, 30);
            Writer.WriteVInt(8); // emz power level
            Writer.WriteScId(16, 31);
            Writer.WriteVInt(8); // mr p  power level
            Writer.WriteScId(16, 32);
            Writer.WriteVInt(8); // max power level
            Writer.WriteScId(16, 34);
            Writer.WriteVInt(8); // jacky power level
            Writer.WriteScId(16, 37);
            Writer.WriteVInt(8); // sprout power level

            Writer.WriteVInt(119); //gadgets and star powers
            Writer.WriteVInt(23);
            Writer.WriteVInt(76);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(77);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(78);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(79);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(80);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(81);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(82);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(83);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(84);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(85);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(86);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(87);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(88);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(89);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(90);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(91);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(92);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(93);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(94);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(99);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(104);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(109);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(114);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(119);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(124);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(129);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(134);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(135);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(136);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(137);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(138);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(139);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(140);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(141);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(142);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(143);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(144);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(145);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(146);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(147);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(148);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(149);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(150);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(151);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(152);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(153);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(154);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(155);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(156);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(157);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(158);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(159);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(160);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(161);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(162);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(163);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(164);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(165);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(166);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(167);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(168);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(169);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(170);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(172);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(174);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(175);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(176);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(181);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(186);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(187);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(192);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(193);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(198);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(199);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(204);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(205);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(210);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(211);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(216);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(217);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(222);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(223);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(240);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(241);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(242);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(243);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(244);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(245);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(246);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(247);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(248);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(249);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(250);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(251);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(252);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(253);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(254);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(255);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(256);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(257);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(258);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(259);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(260);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(261);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(262);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(263);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(264);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(265);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(266);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(267);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(268);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(269);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(270);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(271);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(272);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(273);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(274);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(275);
            Writer.WriteScId(1, 23);
            Writer.WriteVInt(276);
            Writer.WriteVInt(1);

            Writer.WriteVInt(35); // brawlers count

            Writer.WriteScId(16, 0);
            Writer.WriteVInt(2); // shelly "new" tag (value shows in game +1, so value 2 = power 9)
            Writer.WriteScId(16, 1);
            Writer.WriteVInt(2); // colt "new" tag
            Writer.WriteScId(16, 2);
            Writer.WriteVInt(2); // bull "new" tag 
            Writer.WriteScId(16, 3);
            Writer.WriteVInt(2); // brock "new" tag
            Writer.WriteScId(16, 4);
            Writer.WriteVInt(2); // rico "new" tag
            Writer.WriteScId(16, 5);
            Writer.WriteVInt(2); // spike "new" tag
            Writer.WriteScId(16, 6);
            Writer.WriteVInt(2); // barley "new" tag
            Writer.WriteScId(16, 0);
            Writer.WriteVInt(2); // jessie "new" tag
            Writer.WriteScId(16, 8);
            Writer.WriteVInt(2); // nita "new" tag
            Writer.WriteScId(16, 9);
            Writer.WriteVInt(2); // dynamike "new" tag
            Writer.WriteScId(16, 10);
            Writer.WriteVInt(2); // primo "new" tag
            Writer.WriteScId(16, 11);
            Writer.WriteVInt(2); // mortis "new" tag
            Writer.WriteScId(16, 12);
            Writer.WriteVInt(2); // crow "new" tag
            Writer.WriteScId(16, 13);
            Writer.WriteVInt(2); // poco "new" tag
            Writer.WriteScId(16, 14);
            Writer.WriteVInt(2); // bo "new" tag
            Writer.WriteScId(16, 15);
            Writer.WriteVInt(2); // piper "new" tag
            Writer.WriteScId(16, 16);
            Writer.WriteVInt(2); // pam "new" tag
            Writer.WriteScId(16, 17);
            Writer.WriteVInt(2); // tara "new" tag
            Writer.WriteScId(16, 18);
            Writer.WriteVInt(2); // darryl "new" tag
            Writer.WriteScId(16, 19);
            Writer.WriteVInt(2); // peny "new" tag
            Writer.WriteScId(16, 20);
            Writer.WriteVInt(2); // frank "new" tag
            Writer.WriteScId(16, 21);
            Writer.WriteVInt(2); // gene "new" tag
            Writer.WriteScId(16, 22);
            Writer.WriteVInt(2); // tick "new" tag
            Writer.WriteScId(16, 23);
            Writer.WriteVInt(2); // leon "new" tag
            Writer.WriteScId(16, 24);
            Writer.WriteVInt(2); // rosa "new" tag
            Writer.WriteScId(16, 25);
            Writer.WriteVInt(2); // carl "new" tag
            Writer.WriteScId(16, 26);
            Writer.WriteVInt(2); // bibi "new" tag
            Writer.WriteScId(16, 27);
            Writer.WriteVInt(2); // 8bit "new" tag
            Writer.WriteScId(16, 28);
            Writer.WriteVInt(2); // sandy "new" tag
            Writer.WriteScId(16, 29);
            Writer.WriteVInt(2); // bea "new" tag
            Writer.WriteScId(16, 30);
            Writer.WriteVInt(2); // emz "new" tag
            Writer.WriteScId(16, 31);
            Writer.WriteVInt(2); // mr p  "new" tag
            Writer.WriteScId(16, 32);
            Writer.WriteVInt(2); // max "new" tag
            Writer.WriteScId(16, 34);
            Writer.WriteVInt(2); // jacky "new" tag
            Writer.WriteScId(16, 37);


            Writer.WriteVInt(2);

            Writer.WriteVInt(Resources.Gems);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(100);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(2);
            Writer.WriteVInt(1550832808);
            Writer.WriteVInt(-1040385);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
        }
    }
}