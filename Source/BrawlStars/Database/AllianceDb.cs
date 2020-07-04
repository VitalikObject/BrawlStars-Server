using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrawlStars.Core;
using BrawlStars.Logic.Clan;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace BrawlStars.Database
{
    public class AllianceDb
    {
        private const string Name = "clan";
        private static string _connectionString;
        private static long _allianceSeed;

        public AllianceDb()
        {
            _connectionString = new MySqlConnectionStringBuilder
            {
                Server = Resources.Configuration.MySqlServer,
                Database = Resources.Configuration.MySqlDatabase,
                UserID = Resources.Configuration.MySqlUserId,
                Password = Resources.Configuration.MySqlPassword,
                SslMode = MySqlSslMode.None,
                MinimumPoolSize = 4,
                MaximumPoolSize = 20,
                CharacterSet = "utf8mb4"
            }.ToString();

            _allianceSeed = MaxAllianceId();

            if (_allianceSeed > -1) return;

            Logger.Log($"MysqlConnection for clans failed [{Resources.Configuration.MySqlServer}]!", GetType());
            Program.Exit();
        }

        public static async Task ExecuteAsync(MySqlCommand cmd)
        {
            #region Execute

            try
            {
                cmd.Connection = new MySqlConnection(_connectionString);
                await cmd.Connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (MySqlException exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);
            }
            finally
            {
                cmd.Connection?.Close();
            }

            #endregion
        }

        public static long MaxAllianceId()
        {
            #region MaxId

            try
            {
                long seed;

                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var cmd = new MySqlCommand($"SELECT coalesce(MAX(Id), 0) FROM {Name}", connection))
                    {
                        seed = Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    connection.Close();
                }

                return seed;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return -1;
            }

            #endregion
        }

        public static async Task<long> CountAsync()
        {
            #region Count

            try
            {
                long seed;

                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM {Name}", connection))
                    {
                        seed = Convert.ToInt64(await cmd.ExecuteScalarAsync());
                    }

                    await connection.CloseAsync();
                }

                return seed;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return 0;
            }

            #endregion
        }

        public static async Task<Alliance> CreateAsync()
        {
            #region Create

            try
            {
                var id = _allianceSeed++;
                if (id <= -1)
                    return null;

                var alliance = new Alliance(id + 1);

                using (var cmd =
                    new MySqlCommand(
                        $"INSERT INTO {Name} (`Id`, `Trophies`, `RequiredTrophies`, `Type`, `Region`, `Data`) VALUES ({id + 1}, {alliance.Score}, {alliance.RequiredScore}, {alliance.Type}, {alliance.Region}, @data)")
                )
                {
#pragma warning disable 618
                    cmd.Parameters?.AddWithValue("@data",
                        JsonConvert.SerializeObject(alliance, Configuration.JsonSettings));
#pragma warning restore 618

                    await ExecuteAsync(cmd);
                }

                return alliance;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return null;
            }

            #endregion
        }

        public static async Task<Alliance> GetAsync(long id)
        {
            #region Get

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    Alliance alliance = null;

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} WHERE Id = '{id}'", connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            alliance = JsonConvert.DeserializeObject<Alliance>((string) reader["Data"],
                                Configuration.JsonSettings);
                            break;
                        }
                    }

                    await connection.CloseAsync();

                    return alliance;
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return null;
            }

            #endregion
        }

        public static async Task SaveAsync(Alliance alliance)
        {
            #region Save

            try
            {
                using (var cmd =
                    new MySqlCommand(
                        $"UPDATE {Name} SET `Trophies`='{alliance.Score}', `RequiredTrophies`='{alliance.RequiredScore}', `Type`='{alliance.Type}', `Region`='{alliance.Region}', `Data`=@data WHERE Id = '{alliance.Id}'")
                )
                {
#pragma warning disable 618
                    cmd.Parameters?.AddWithValue("@data",
                        JsonConvert.SerializeObject(alliance, Configuration.JsonSettings));
#pragma warning restore 618

                    await ExecuteAsync(cmd);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);
            }

            #endregion
        }

        public static async Task DeleteAsync(long id)
        {
            #region Delete

            try
            {
                using (var cmd = new MySqlCommand(
                    $"DELETE FROM {Name} WHERE Id = '{id}'")
                )
                {
                    await ExecuteAsync(cmd);

                    /*if (Redis.IsConnected)
                        await Redis.UncacheAllianceAsync(id);*/
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);
            }

            #endregion
        }

        public static async Task<List<Alliance>> GetGlobalAlliancesAsync()
        {
            #region Global

            var list = new List<Alliance>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} ORDER BY `Trophies` DESC LIMIT 200",
                        connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                            list.Add(JsonConvert.DeserializeObject<Alliance>((string) reader["Data"],
                                Configuration.JsonSettings));
                    }

                    await connection.CloseAsync();
                }

                return list;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return list;
            }

            #endregion
        }
    }
}