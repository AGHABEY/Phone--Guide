using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Phone.Entities;


namespace Phone.Core
{
    public class DataBaseLogicLayer
    {

        List<GuideRecord> records;
        public DataBaseLogicLayer()
        {
            records = new List<GuideRecord>();
            DataBaseControl();
        }

        private void DataBaseControl()
        {
            bool fileControl = Directory.Exists(@"c:\Phone\");
            if (!fileControl)
            {
                Directory.CreateDirectory(@"c:\Phone\");
                User demo = new User();
                demo.ID = Guid.NewGuid();
                demo._name = "Test";
                demo._password = "Test1";
                string JsonUsertext = Newtonsoft.Json.JsonConvert.SerializeObject(demo);
                File.WriteAllText(@"c:\Phone\user.json",JsonUsertext);

            }
        }

        public int userControl(User user)
        {
            int userResult = 0;
            if (File.Exists(@"c:\Phone\user.json"))
            {
                string JsonUserText = File.ReadAllText(@"c:\Phone\user.json");
                List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(JsonUserText);
                userResult = users.FindAll(I => I._name == user._name && I._password == user._password).ToList().Count();
            }

            return userResult;
        }

        public int newRecord(GuideRecord gr)
        {
            int final = 0;

            try
            {
                GetGuideRecords();
                records.Add(gr);
                JsonUpdate();
                final = 1;
            }
            catch (Exception ex)
            {
                final = 0;
                //log operation
                throw;
            }

            return final;
        }
        public int UpdateRecord(GuideRecord G)
        {
            int result = 0;
            try
            {
                GetGuideRecords();
                int Index = records.FindIndex(I => I._ID == G._ID);
                if (Index>-1)
                {
                    records[Index]._name = G._name;
                    records[Index]._surname = G._surname;
                    records[Index]._phoneNumber1 = G._phoneNumber1;
                    records[Index]._phoneNumber2 = G._phoneNumber2;
                    records[Index]._phoneNumber3 = G._phoneNumber3;
                    records[Index]._adress = G._adress;
                    records[Index]._emailAdress = G._emailAdress;
                    records[Index]._text = G._text;
                }
                JsonUpdate();
                result = 1;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public int DeleteRecord(Guid ID)
        {
            int result = 0;
            try
            {
                GetGuideRecords();
                GuideRecord deletedValue = records.Find(I => I._ID == ID);
                if (deletedValue!=null)
                {
                    records.Remove(deletedValue);
                }
                JsonUpdate();
                result = 1;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public List<GuideRecord> GetGuideRecords()
        {
            if (File.Exists(@"c:\Phone\Guide.json"))
            {
                string JsonDBText = File.ReadAllText(@"c:\Phone\Guide.json");
                records = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GuideRecord>>(JsonDBText);
            }
            return records;
        }

        private void JsonUpdate()
        {
            if (records!=null && records.Count>0)
            {
                string jsonDB = Newtonsoft.Json.JsonConvert.SerializeObject(records);
                File.WriteAllText(@"c:\Phone\Guide.json", jsonDB);

            }
        }

    }
}
