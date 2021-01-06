using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace Parsing
{
    class Program
    {

        static void Main(string[] args)
        {
            //TCX PARSANJE
            var tcx = new OpenTcx.Tcx();
            //var data = tcx.AnalyzeTcxFile(@"D:\Downloads\Sport5\Sport5\1\18.tcx");
            //string path = @"D:\Downloads\Sport5\Sport5\1";

            string path = @"D:\Downloads\Sport5\Sport5\4";

            List<Sport> ListFill = new List<Sport>();

            foreach (string imeDat in Directory.GetFiles(path, "*.tcx").Select(Path.GetFileName))
            {
                var data = tcx.AnalyzeTcxFile(path + @"\" + imeDat);
                //var data = tcx.AnalyzeTcxFile(@"D:\Downloads\Sport5\Sport5\1\18.tcx");
                if (data == null) return;
                Console.WriteLine("Sports Activity Count:" + data.Activities.Activity.Length);
                if (data.Activities.Activity.Length < 1) return;
                var activity0 = data.Activities.Activity[0];
                try
                {
                    if (activity0.Sport.ToString() == "Biking")
                    {


                        Console.WriteLine("Ime aktivnosti:" + activity0.Sport);
                        Console.WriteLine();
                        Console.WriteLine("Kdaj je posneta:" + activity0.Id);
                        Console.WriteLine();
                        Console.WriteLine("Trajanje aktivnosti:" + data.Activities.Activity[0].Lap[0].TotalTimeSeconds);
                        Console.WriteLine();
                        Console.WriteLine("St prevozenih km:" + data.Activities.Activity[0].Lap[0].DistanceMeters);
                        Console.WriteLine();
                        Console.WriteLine("Vzpon:" + data.Activities.Activity[0].Lap[0].Track[0].AltitudeMeters);
                        Console.WriteLine();
                        Console.WriteLine("Kalorije:" + data.Activities.Activity[0].Lap[0].Calories);
                        Console.WriteLine();
                        Console.WriteLine("Povp hitrost:" + data.Activities.Activity[0].Lap[0].MaximumSpeed);
                        Console.WriteLine();
                        Console.WriteLine("Povp kadenca:" + data.Activities.Activity[0].Lap[0].Track[0].Cadence);
                        Console.WriteLine();
                        Console.WriteLine("Max kadenca:" + data.Activities.Activity[0].Lap[0].Cadence);
                        Sport a = new Sport();

                        a.Ime_aktivnosti = activity0.Sport.ToString();

                        a.Cas_posnetka = activity0.Id.ToString();

                        a.Trajanje_aktivnosti = data.Activities.Activity[0].Lap[0].TotalTimeSeconds.ToString();

                        a.Stevilo_prevozenih_km = data.Activities.Activity[0].Lap[0].DistanceMeters.ToString();

                        a.Skupen_vzpon = data.Activities.Activity[0].Lap[0].Track[0].AltitudeMeters.ToString();

                        a.Porabljene_kalorije = data.Activities.Activity[0].Lap[0].Calories.ToString();

                        a.Povp_hitrost = data.Activities.Activity[0].Lap[0].MaximumSpeed.ToString();

                        a.Povp_kadenca = data.Activities.Activity[0].Lap[0].Track[0].Cadence.ToString();

                        a.Max_kadenca = data.Activities.Activity[0].Lap[0].Cadence.ToString();

                        ListFill.Add(a);
                    }
                    else
                    {
                        continue;
                    }
                }
                catch
                {
                }
            }


            //POLNJENJE TXC PODATKOV
            SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();
            sql.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\3PS\Parsing\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(sql.ConnectionString))
            {
                conn.Open();

                foreach (var a in ListFill)
                {

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Dimen2 (Calories, Altitude, Cadence, Avg_Cadence ) VALUES (@Porabljene_kalorije, @Skupen_vzpon, @Max_kadenca, @Povp_kadenca)"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@Porabljene_kalorije", a.Porabljene_kalorije);
                        cmd.Parameters.AddWithValue("@Skupen_vzpon", a.Skupen_vzpon);
                        cmd.Parameters.AddWithValue("@Max_kadenca", a.Max_kadenca);
                        cmd.Parameters.AddWithValue("@Povp_kadenca", a.Povp_kadenca);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Dimen1 (Time, Distance, Speed) VALUES (@Trajanje_aktivnosti, @Stevilo_prevozenih_km, @Povp_hitrost)"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@Trajanje_aktivnosti", a.Trajanje_aktivnosti);
                        cmd.Parameters.AddWithValue("@Stevilo_prevozenih_km", a.Stevilo_prevozenih_km);
                        cmd.Parameters.AddWithValue("@Povp_hitrost", a.Povp_hitrost);
                        cmd.ExecuteNonQuery();
                    }


                    //using (SqlCommand cmd = new SqlCommand("INSERT INTO Table_fact (Name, Time_recorded, Total_km, Total_time, Total_calories) VALUES (@Ime_aktivnosti, @Cas_posnetka, @Stevilo_prevozenih_km, @Trajanje_aktivnosti, @Porabljene_kalorije )"))
                    //{

                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.Connection = conn;
                    //    cmd.Parameters.AddWithValue("@Ime_aktivnosti", a.Ime_aktivnosti);
                    //    cmd.Parameters.AddWithValue("@Cas_posnetka", a.Cas_posnetka);
                    //    cmd.Parameters.AddWithValue("@Stevilo_prevozenih_km", a.Stevilo_prevozenih_km);
                    //    cmd.Parameters.AddWithValue("@Trajanje_aktivnosti", a.Trajanje_aktivnosti);
                    //    cmd.Parameters.AddWithValue("@Porabljene_kalorije", a.Porabljene_kalorije);

                    //    cmd.ExecuteNonQuery();
                    //}
                }
                conn.Close();
            }
            Console.ReadKey();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //GPX PARSANJE
            /// Load the Xml document for parsing
            //string path = @"D:\Downloads\Sport3\Sport3\Athlete14";

            //List < Sport > Listfill2 = new List<Sport>();

            //foreach (string file in Directory.GetFiles(path, "*.gpx").Select(Path.GetFileName))
            //    {
            //        //Load the namespace for a standard GPX document
            //        XDocument gpxDoc = XDocument.Load(path + @"\" + file);

            //        //Load the namespace for a standard GPX document
            //        XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            //        XNamespace gpxtpx = XNamespace.Get("http://www.garmin.com/xmlschemas/TrackPointExtension/v1");

            //        /// When passed a file, open it and parse all waypoints from it.
            //        /// </summary>
            //        /// <param name="sFile">Fully qualified file name (local)</param>
            //        /// <returns>string containing line delimited waypoints from
            //        /// the file (for test)</returns>
            //        /// <remarks>Normally, this would be used to populate the
            //        /// appropriate object model</remarks>

            //        try
            //        {
            //            // Populate detailed track segments
            //            // in the object model here.
            //            var waypoints = from waypoint in gpxDoc.Descendants(gpx + "trkpt")
            //                            select new
            //                            {
            //                                Latitude = waypoint.Attribute("lat") != null ? waypoint.Attribute("lat").Value : null,
            //                                Longitude = waypoint.Attribute("lon") != null ? waypoint.Attribute("lon").Value : null,
            //                                Ele = waypoint.Element(gpx + "ele") != null ? waypoint.Element(gpx + "ele").Value : null,
            //                                Time = waypoint.Element(gpx + "time") != null ? waypoint.Element(gpx + "time").Value : null,
            //                                Atemp = waypoint.Element(gpx + "extensions").Element(gpxtpx + "TrackPointExtension").Element(gpxtpx + "atemp") != null ? waypoint.Element(gpx + "extensions").Element(gpxtpx + "TrackPointExtension").Element(gpxtpx + "atemp").Value : null,
            //                                Hr = waypoint.Element(gpx + "extensions").Element(gpxtpx + "TrackPointExtension").Element(gpxtpx + "hr") != null ? waypoint.Element(gpx + "extensions").Element(gpxtpx + "TrackPointExtension").Element(gpxtpx + "hr").Value : null,
            //                                Cad = waypoint.Element(gpx + "extensions").Element(gpxtpx + "TrackPointExtension").Element(gpxtpx + "cad") != null ? waypoint.Element(gpx + "extensions").Element(gpxtpx + "TrackPointExtension").Element(gpxtpx + "cad").Value : null
            //                            };
            //            /// When passed a file, open it and parse all tracks
            //            /// and track segments from it.
            //            /// </summary>
            //            /// <param name="sFile">Fully qualified file name (local)</param>
            //            /// <returns>string containing line delimited waypoints from the
            //            /// file (for test)</returns>
            //            Sport elemnt = new Sport();
            //            elemnt.Cas_posnetka = waypoints.First().Time;
            //            elemnt.Ime_aktivnosti = "null";
            //            string trajanje = ((DateTime.Parse(waypoints.Last().Time) - DateTime.Parse(waypoints.First().Time)).TotalMilliseconds).ToString();
            //            elemnt.Porabljene_kalorije = "null";
            //            elemnt.Stevilo_prevozenih_km = "null";
            //            elemnt.Povp_hitrost = "null";
            //            elemnt.Trajanje_aktivnosti = TimeSpan.FromMilliseconds(long.Parse(trajanje)).ToString();
            //            elemnt.Skupen_vzpon = (double.Parse(waypoints.Max(x => x.Ele)) - double.Parse(waypoints.Min(x => x.Ele))).ToString();
            //            elemnt.Povp_kadenca = waypoints.Average(x => long.Parse(x.Cad)).ToString();
            //            elemnt.Max_kadenca = (waypoints.Max(x => x.Cad)).ToString();

            //            Listfill2.Add(elemnt);
            //        }
            //        catch
            //        {
            //        }
            //    }

            ////POLNJENJE GPX PODATKOV              
            //SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();
            //sql.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\3PS\Parsing\Database1.mdf;Integrated Security=True";
            //using (SqlConnection conn = new SqlConnection(sql.ConnectionString))
            //{
            //    conn.Open();

            //    foreach (var a in Listfill2)
            //    {
            //        using (SqlCommand cmd = new SqlCommand("INSERT INTO Dimen2 (Calories, Altitude, Cadence, Avg_Cadence ) VALUES (@Porabljene_kalorije, @Skupen_vzpon, @Max_kadenca, @Povp_kadenca)"))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = conn;
            //            cmd.Parameters.AddWithValue("@Porabljene_kalorije", a.Porabljene_kalorije);
            //            cmd.Parameters.AddWithValue("@Skupen_vzpon", a.Skupen_vzpon);
            //            cmd.Parameters.AddWithValue("@Max_kadenca", a.Max_kadenca);
            //            cmd.Parameters.AddWithValue("@Povp_kadenca", a.Povp_kadenca);
            //            cmd.ExecuteNonQuery();
            //        }

            //        using (SqlCommand cmd = new SqlCommand("INSERT INTO Dimen1 (Time, Distance, Speed) VALUES (@Trajanje_aktivnosti, @Stevilo_prevozenih_km, @Povp_hitrost)"))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = conn;
            //            cmd.Parameters.AddWithValue("@Trajanje_aktivnosti", a.Trajanje_aktivnosti);
            //            cmd.Parameters.AddWithValue("@Stevilo_prevozenih_km", a.Stevilo_prevozenih_km);
            //            cmd.Parameters.AddWithValue("@Povp_hitrost", a.Povp_hitrost);
            //            cmd.ExecuteNonQuery();
            //        }

            //        //using (SqlCommand cmd = new SqlCommand("INSERT INTO Table_fact (Name, Time_recorded, Total_km, Total_time, Total_calories) VALUES (@Ime_aktivnosti, @Cas_posnetka, @Stevilo_prevozenih_km, @Trajanje_aktivnosti, @Porabljene_kalorije )"))
            //        //{
            //        //    cmd.CommandType = CommandType.Text;
            //        //    cmd.Connection = conn;
            //        //    cmd.Parameters.AddWithValue("@Ime_aktivnosti", a.Ime_aktivnosti);
            //        //    cmd.Parameters.AddWithValue("@Cas_posnetka", a.Cas_posnetka);
            //        //    cmd.Parameters.AddWithValue("@Stevilo_prevozenih_km", a.Stevilo_prevozenih_km);
            //        //    cmd.Parameters.AddWithValue("@Trajanje_aktivnosti", a.Trajanje_aktivnosti);
            //        //    cmd.Parameters.AddWithValue("@Porabljene_kalorije", a.Porabljene_kalorije);


            //        //    cmd.ExecuteNonQuery();
            //        //}
            //    }
            //    conn.Close();
            //}
        }
        }
    }
    

        
   
        
    

        

    
        



