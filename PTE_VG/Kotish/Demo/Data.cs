using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTE_VG.Kotish.Codes;

namespace PTE_VG.Kotish.Demo
{
    public class Question
    {
        public String Title { get; set; }
        public String Duration { get; set; }
        public String Text { get; set; }
        public String Image { get; set; }
        public String Audio { get; set; }
        public String PDF { get; set; }
        public String Fill_Ups { get; set; }
        public String Accept_Text { get; set; }
        public String Audio_Ans { get; set; }
        public String TimeStamp { get; set; }
        public String Type { get; set; }

    }
    public class Data
    {
        public List<Question> Load()
        {
            Search search = new Search();
            List<Question> files = new List<Question>();
            for (int i = 0; i<search.Question().Rows.Count; i++)
            {
                files.Add(new Question
                {
                    Title = search.Question().Rows[i]["Title"].ToString(),
                    Duration = search.Question().Rows[i]["Duration"].ToString(),
                    Text = search.Question().Rows[i]["Text"].ToString(),
                    Image = search.Question().Rows[i]["Image"].ToString(),
                    Audio = search.Question().Rows[i]["Audio"].ToString(),
                    PDF = search.Question().Rows[i]["PDF"].ToString(),
                    Fill_Ups = search.Question().Rows[i]["Fill_Ups"].ToString(),
                    Accept_Text = search.Question().Rows[i]["Accept_Text"].ToString(),
                    Audio_Ans = search.Question().Rows[i]["Audio_Ans"].ToString(),
                    TimeStamp = search.Question().Rows[i]["TimeStamp"].ToString(),
                    Type = search.Question().Rows[i]["Type"].ToString(),
                });
            }
            return files;
        }
    }
}