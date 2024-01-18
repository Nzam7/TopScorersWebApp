using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopScorersWebApp.Models;

namespace TopScorersWebApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<string> GetTopScorers(string base64File)
        {
            var people = new List<Person>();
            var result = new List<string>();

            if (!string.IsNullOrEmpty(base64File))
            {
                byte[] fileBytes = Convert.FromBase64String(base64File);
                using (var stream = new MemoryStream(fileBytes))
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            people.Add(new Person
                            {
                                FirstName = parts[0],
                                SecondName = parts[1],
                                Score = int.Parse(parts[2])
                            });
                        }
                    }
                }

                if (people.Count > 0)
                {
                    var maxScore = people.Max(p => p.Score);
                    var topScorers = people.Where(p => p.Score == maxScore)
                                           .OrderBy(p => p.FullName)
                                           .Select(p => p.FullName)
                                           .ToList();

                    result.Add("Top Scorers:");
                    result.AddRange(topScorers);
                    result.Add($"Score: {maxScore}");
                }
            }

            return result;
        }
    }
}