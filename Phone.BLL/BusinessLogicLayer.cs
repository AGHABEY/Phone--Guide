using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone.Core;
using Phone.Entities;

namespace Phone.BLL
{
    public class BusinessLogicLayer
    {
        DataBaseLogicLayer DLL;
        public BusinessLogicLayer()
        {
            DLL = new DataBaseLogicLayer();

        }
        public int userControl(string name,string password)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
            {
                User user = new User();
                user._name = name;
                user._password = password;

                result = DLL.userControl(user);
            }
            else
            {
                result = -100;// her hansi 1 yalnisliq bas verdi
            }

            return result;
        }

        public int newRecord(Guid _ID, string _name, string _surname, string _phoneNumber1, string _phoneNumber2, string _phoneNumber3, string _adress, string _emailAdress, string _text)
        {
            int result = 0;
            if (_ID!=Guid.Empty && !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname) && !string.IsNullOrEmpty(_phoneNumber1))
            {
                GuideRecord record = new GuideRecord();
                record._ID = _ID;
                record._name = _name;
                record._surname = _surname;
                record._phoneNumber1 = _phoneNumber1;
                record._phoneNumber2 = _phoneNumber2;
                record._phoneNumber3 = _phoneNumber3;
                record._adress = _adress;
                record._emailAdress = _emailAdress;
                record._text = _text;

                result = DLL.newRecord(record);

            }
            else
            {
                result = -100;// eksik parametr xetasi.
            }
            return result;
        }
        public int updateRecord(Guid _ID, string _name, string _surname, string _phoneNumber1, string _phoneNumber2, string _phoneNumber3, string _adress, string _emailAdress, string _text)
        {
            int result = 0;
            if (_ID != Guid.Empty && !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname) && !string.IsNullOrEmpty(_phoneNumber1))
            {
                GuideRecord record = new GuideRecord();
                record._ID = _ID;
                record._name = _name;
                record._surname = _surname;
                record._phoneNumber1 = _phoneNumber1;
                record._phoneNumber2 = _phoneNumber2;
                record._phoneNumber3 = _phoneNumber3;
                record._adress = _adress;
                record._emailAdress = _emailAdress;
                record._text = _text;

                result = DLL.UpdateRecord(record);

            }
            else
            {
                result = -100;// eksik parametr xetasi.
            }
            return result;
        }
        public int deleteRecord(Guid ID)
        {
            return DLL.DeleteRecord(ID);
        }

            public List<GuideRecord> GetGuideRecords()
        {
            return DLL.GetGuideRecords();
        }
    }
}
