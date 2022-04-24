using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace ADO.NET_EFCoreOct2021
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.CONNECTION_STRING);

            await sqlConnection.OpenAsync();

            Console.Write("Enter villain id: ");
            int villainId = int.Parse(Console.ReadLine());
            

            await using (sqlConnection)
            {
                await PrintVillainMinionsInfoByIdAsync(sqlConnection, villainId);
            }


            //await using (sqlConnection)
           // {
                        //SqlCommand crDbCmd = new SqlCommand(Queries.CREATE_DB_QUERY, sqlConnection);

                        //await crDbCmd.ExecuteNonQueryAsync();

                        //Console.WriteLine("Database [ADONETDB2] created successfully");


               // await PrintVillainsWithMoreThan3MinionsAsync(sqlConnection);

           // }

        }
        // Peroblem 02
        private static async Task PrintVillainsWithMoreThan3MinionsAsync(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(Queries.VILAINS_WITH_MORE_THAN_3_MINIONS, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                while (await sqlDataReader.ReadAsync())
                {
                    string villainName = sqlDataReader.GetString(0);
                    int minionsCount = sqlDataReader.GetInt32(1);

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }
        //Problem 03
        private static async Task PrintVillainMinionsInfoByIdAsync(SqlConnection sqlConnection, int villainId)
        {
            SqlCommand getVillainNameCmd = new SqlCommand(Queries.VILAINS_NAME_BY_ID, sqlConnection);

            //Prevents SQL Injection.
            //Create Id Parameter that can be used multiple times
            SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            idParameter.Value = villainId;

            // possible to use:
            //getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            getVillainNameCmd.Parameters.Add(idParameter);

            object villainNameObject = await getVillainNameCmd.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = (string)villainNameObject;

            SqlCommand villainMinionsInfoCmd = new SqlCommand(Queries.VILAINS_NAME_INFO_BY_ID, sqlConnection);
            villainMinionsInfoCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader sqlDataReader = await villainMinionsInfoCmd.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                Console.WriteLine($"Villain: {villainName}");

                if (!sqlDataReader.HasRows)
                {
                    //There are no minions for giveen villain
                    Console.WriteLine(("(no minions)"));
                }
                else
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        long rowNumber = sqlDataReader.GetInt64(0);
                        string minionName = sqlDataReader.GetString(1);
                        int minionAge = sqlDataReader.GetInt32(2);

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            
            }

        }
    }
}
