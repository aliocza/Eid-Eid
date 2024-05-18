using Eid.Abstract;
using System;

namespace Eid.Model
{
    public class BelgianEidModel : ModelAbstract
    {
        public enum EidAttributes
        {
            ATR,
            CARD_DATA,
            carddata_serialnumber,
            carddata_comp_code,
            carddata_os_number,
            carddata_os_version,
            carddata_soft_mask_number,
            carddata_soft_mask_version,
            carddata_appl_version,
            carddata_glob_os_version,
            carddata_appl_int_version,
            carddata_pkcs1_support,
            carddata_key_exchange_version,
            carddata_appl_lifecycle,
            DATA_FILE,
            ADDRESS_FILE,
            PHOTO_FILE,
            SIGN_DATA_FILE,
            SIGN_ADDRESS_FILE,
            card_number,
            chip_number,
            validity_begin_date,
            validity_end_date,
            issuing_municipality,
            national_number,
            surname,
            firstnames,
            first_letter_of_third_given_name,
            nationality,
            location_of_birth,
            date_of_birth,
            gender,
            nobility,
            document_type,
            special_status,
            photo_hash,
            duplicata,
            special_organization,
            member_of_family,
            date_and_country_of_protection,
            work_permit_mention,
            employer_vat_1,
            employer_vat_2,
            regional_file_number,
            basic_key_hash,
            address_street_and_number,
            address_zip,
            address_municipality,
            CERT_RN_FILE
        }

        private String ATR;
        private String CARD_DATA;
        private String carddata_serialnumber;
        private String carddata_comp_code;
        private String carddata_os_number;
        private String carddata_os_version;
        private String carddata_soft_mask_number;
        private String carddata_soft_mask_version;
        private String carddata_appl_version;
        private String carddata_glob_os_version;
        private String carddata_appl_int_version;
        private String carddata_pkcs1_support;
        private String carddata_key_exchange_version;
        private String carddata_appl_lifecycle;
        private String DATA_FILE; // the identity data file
        private String card_number; // ASCII
        private String chip_number;
        private String validity_begin_date; //the card validity begin date ASCII
        private String validity_end_date; //the card validity end date ASCII
        private String issuing_municipality; //the card delivery municipality
        private String national_number; //ASCII
        private String surname;
        private String firstnames;
        private String first_letter_of_third_given_name;
        private String nationality;
        private String location_of_birth; //Birth date; encoded as (see below)
        private String date_of_birth;
        private String gender; //M: man / F/V/W: woman ASCII
        private String nobility; //noble condition
        private String document_type; // 1: Belgian citizen	6: Kids card(< 12 year)	7: Bootstrap card	8: “Habilitation / Machtigings-” card	11: Foreigner card type A	12: Foreigner card type B 13: Foreigner card type C	14: Foreigner card type D	15: Foreigner card type E	16: Foreigner card type E+	17: Foreigner card type F	18: Foreigner card type F+	19: Foreigner card type H	20: Foreigner card type I	21: Foreigner card type J
        private String special_status; //0: No status 2: Extended minority  ASCII
        private String photo_hash; //hash of the photo file
        private String ADDRESS_FILE; //the address file
        private String address_street_and_number; //the streetname and number
        private String address_zip; //the zip-code of your town/city
        private String address_municipality; //your town/city
        private String PHOTO_FILE; //the photo
        private String CERT_RN_FILE; //RN Certificate
        private String SIGN_DATA_FILE; //the signature of the identity file
        private String SIGN_ADDRESS_FILE; //the signature of the address file

        private String duplicata; //ASCII
        private String special_organization; //1: SHAPE 2: NATO ASCII
        private String member_of_family; //(this is a boolean value)
        private String date_and_country_of_protection; //ASCII dd.MM.yyyy-A2
        private String work_permit_mention;//ASCII
        private String employer_vat_1;//ASCII
        private String employer_vat_2;//ASCII
        private String regional_file_number;//ASCII
        private String basic_key_hash; //SHA256 hash of card public key Only available on applet v1.8 cards


        public void SetDATA_FILE(byte[] value)
        {
            if (value != null)
            {
                this.DATA_FILE = Convert.ToBase64String(value);
            }
        }
        public String GetDATA_FILE()
        {
            return this.DATA_FILE;
        }


        public void SetADDRESS_FILE(byte[] value)
        {
            if (value != null)
            {
                this.ADDRESS_FILE = Convert.ToBase64String(value);
            }
        }
        public String GetADDRESS_FILE()
        {
            return this.ADDRESS_FILE;
        }


        public void SetPHOTO_FILE(byte[] value)
        {
            if (value != null)
            {
                this.PHOTO_FILE = Convert.ToBase64String(value);
            }
        }
        public String GetPHOTO_FILE()
        {
            return this.PHOTO_FILE;
        }


        public void SetSIGN_DATA_FILE(byte[] value)
        {
            if (value != null)
            {
                this.SIGN_DATA_FILE = Convert.ToBase64String(value);
            }
        }
        public String GetSIGN_DATA_FILE()
        {
            return this.SIGN_DATA_FILE;
        }


        public void SetSIGN_ADDRESS_FILE(byte[] value)
        {
            if (value != null)
            {
                this.SIGN_ADDRESS_FILE = Convert.ToBase64String(value);
            }
        }
        public String GetSIGN_ADDRESS_FILE()
        {
            return this.SIGN_ADDRESS_FILE;
        }


        public void Setcard_number(byte[] value)
        {
            if (value != null)
            {
                this.card_number = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getcard_number()
        {
            return this.card_number;
        }


        public void Setchip_number(byte[] value)
        {
            if (value != null)
            {
                this.chip_number = BitConverter.ToString(value).Replace("-", string.Empty);
            }
        }
        public String Getchip_number()
        {
            return this.chip_number;
        }


        public void Setvalidity_begin_date(byte[] value)
        {
            if (value != null)
            {
                this.validity_begin_date = Utils.FormateData.FormatDate(System.Text.Encoding.UTF8.GetString(value));
            }
        }
        public String Getvalidity_begin_date()
        {
            return this.validity_begin_date;
        }


        public void Setvalidity_end_date(byte[] value)
        {
            if (value != null)
            {
                this.validity_end_date = Utils.FormateData.FormatDate(System.Text.Encoding.UTF8.GetString(value));
            }
        }
        public String Getvalidity_end_date()
        {
            return this.validity_end_date;
        }

        public void Setissuing_municipality(byte[] value)
        {
            if (value != null)
            {
                this.issuing_municipality = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getissuing_municipality()
        {
            return this.issuing_municipality;
        }

        public void Setnational_number(byte[] value)
        {
            if (value != null)
            {
                this.national_number = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getnational_number()
        {
            return this.national_number;
        }

        public void Setsurname(byte[] value)
        {
            if (value != null)
            {
                this.surname = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getsurname()
        {
            return this.surname;
        }


        public void Setfirstnames(byte[] value)
        {
            if (value != null)
            {
                this.firstnames = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getfirstnames()
        {
            return this.firstnames;
        }

        public void Setfirst_letter_of_third_given_name(byte[] value)
        {
            if (value != null)
            {
                this.first_letter_of_third_given_name = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getfirst_letter_of_third_given_name()
        {
            return this.first_letter_of_third_given_name;
        }

        public void Setnationality(byte[] value)
        {
            if (value != null)
            {
                this.nationality = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getnationality()
        {
            return this.nationality;
        }

        public void Setlocation_of_birth(byte[] value)
        {
            if (value != null)
            {
                this.location_of_birth = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getlocation_of_birth()
        {
            return this.location_of_birth;
        }

        public void Setdate_of_birth(byte[] value)
        {
            if (value != null)
            {
                this.date_of_birth = Utils.FormateData.FormatBirthdate(System.Text.Encoding.UTF8.GetString(value));
            }
        }
        public String Getdate_of_birth()
        {
            return this.date_of_birth;//DateOnly.ParseExact(this.date_of_birth, "yyyy-MM-dd", CultureInfo.InvariantCulture); ;
        }

        public void Setgender(byte[] value)
        {
            if (value != null)
            {
                this.gender = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getgender()
        {
            return this.gender;
        }

        public void Setnobility(byte[] value)
        {
            if (value != null)
            {
                this.nobility = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getnobility()
        {
            return this.nobility;
        }

        public void Setdocument_type(byte[] value)
        {
            if (value != null)
            {
                this.document_type = (System.Text.Encoding.UTF8.GetString(value)).TrimStart('0');
            }
        }
        public String Getdocument_type()
        {
            return this.document_type;
        }

        public void Setspecial_status(byte[] value)
        {
            if (value != null)
            {
                this.special_status = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getspecial_status()
        {
            return this.special_status;
        }

        public void Setphoto_hash(byte[] value)
        {
            if (value != null)
            {
                this.photo_hash = Convert.ToBase64String(value);
            }
        }
        public String Getphoto_hash()
        {
            return this.photo_hash;
        }

        public void Setduplicata(byte[] value)
        {
            if (value != null)
            {
                this.duplicata = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getduplicata()
        {
            return this.duplicata;
        }

        public void Setspecial_organization(byte[] value)
        {
            if (value != null)
            {
                this.special_organization = (System.Text.Encoding.UTF8.GetString(value).TrimStart('0'));
            }
        }
        public String Getspecial_organization()
        {
            return this.special_organization;
        }

        public void Setmember_of_family(byte[] value)
        {
            if (value != null)
            {
                this.member_of_family = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getmember_of_family()
        {
            return this.member_of_family;
        }

        public void Setdate_and_country_of_protection(byte[] value)
        {
            if (value != null)
            {
                this.date_and_country_of_protection = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getdate_and_country_of_protection()
        {
            return this.date_and_country_of_protection;
        }

        public void Setwork_permit_mention(byte[] value)
        {
            if (value != null)
            {
                this.work_permit_mention = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getwork_permit_mention()
        {
            return this.work_permit_mention;
        }

        public void Setemployer_vat_1(byte[] value)
        {
            if (value != null)
            {
                this.employer_vat_1 = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getemployer_vat_1()
        {
            return this.employer_vat_1;
        }

        public void Setemployer_vat_2(byte[] value)
        {
            if (value != null)
            {
                this.employer_vat_2 = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getemployer_vat_2()
        {
            return this.employer_vat_2;
        }

        public void Setregional_file_number(byte[] value)
        {
            if (value != null)
            {
                this.regional_file_number = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getregional_file_number()
        {
            return this.regional_file_number;
        }

        public void Setbasic_key_hash(byte[] value)
        {
            if (value != null)
            {
                this.basic_key_hash = Convert.ToBase64String(value);
            }
        }
        public String Getbasic_key_hash()
        {
            return this.basic_key_hash;
        }

        public void Setaddress_street_and_number(byte[] value)
        {
            if (value != null)
            {
                this.address_street_and_number = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getaddress_street_and_number()
        {
            return this.address_street_and_number;
        }

        public void Setaddress_zip(byte[] value)
        {
            if (value != null)
            {
                this.address_zip = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getaddress_zip()
        {
            return this.address_zip;
        }

        public void Setaddress_municipality(byte[] value)
        {
            if (value != null)
            {
                this.address_municipality = System.Text.Encoding.UTF8.GetString(value);
            }
        }
        public String Getaddress_municipality()
        {
            return this.address_municipality;
        }


        public void SetCERT_RN_FILE(byte[] value)
        {
            if (value != null)
            {
                this.CERT_RN_FILE = Convert.ToBase64String(value);
            }
        }
        public String GetCERT_RN_FILE()
        {
            return this.CERT_RN_FILE;
        }

        public void SetATR(byte[] value)
        {
            if (value != null)
            {
                this.ATR = Convert.ToBase64String(value);
            }
        }
        public String GetATR()
        {
            return this.ATR;
        }


        public void SetCARD_DATA(byte[] value)
        {
            if (value != null)
            {
                this.CARD_DATA = Convert.ToBase64String(value);
            }
        }
        public String GetCARD_DATA()
        {
            return this.CARD_DATA;
        }



        public void Setcarddata_serialnumber(byte[] value)
        {
            if (value != null)
            {
                this.carddata_serialnumber = Convert.ToBase64String(value);
            }
        }
        public String Getcarddata_serialnumber()
        {
            return this.carddata_serialnumber;
        }



        public String Getcarddata_comp_code()
        {
            return this.carddata_comp_code;
        }

        public void Setcarddata_comp_code(byte[] value)
        {
            if (value != null)
            {
                this.carddata_comp_code = Convert.ToBase64String(value);
            }
        }

        public String Getcarddata_os_number()
        {
            return this.carddata_os_number;
        }

        public void Setcarddata_os_number(byte[] value)
        {
            if (value != null)
            {
                this.carddata_os_number = System.Text.Encoding.UTF8.GetString(value);
            }
        }


        public String Getcarddata_os_version()
        {
            return this.carddata_os_version;
        }

        public void Setcarddata_os_version(byte[] value)
        {
            if (value != null)
            {
                this.carddata_os_version = Convert.ToBase64String(value);
            }
        }


        public String Getcarddata_soft_mask_number()
        {
            return this.carddata_soft_mask_number;
        }

        public void Setcarddata_soft_mask_number(byte[] value)
        {
            if (value != null)
            {
                this.carddata_soft_mask_number = Convert.ToBase64String(value);
            }
        }


        public String Getcarddata_soft_mask_version()
        {
            return this.carddata_soft_mask_version;
        }

        public void Setcarddata_soft_mask_version(byte[] value)
        {
            if (value != null)
            {
                this.carddata_soft_mask_version = Convert.ToBase64String(value);
            }
        }


        public String Getcarddata_appl_version()
        {
            return this.carddata_appl_version;
        }

        public void Setcarddata_appl_version(byte[] value)
        {
            if (value != null)
            {
                this.carddata_appl_version = Convert.ToBase64String(value);
            }
        }


        public String Getcarddata_glob_os_version()
        {
            return this.carddata_glob_os_version;
        }

        public void Setcarddata_glob_os_version(byte[] value)
        {
            if (value != null)
            {
                this.carddata_glob_os_version = Convert.ToBase64String(value);
            }
        }

        public String Getcarddata_appl_int_version()
        {
            return this.carddata_appl_int_version;
        }

        public void Setcarddata_appl_int_version(byte[] value)
        {
            if (value != null)
            {
                this.carddata_appl_int_version = Convert.ToBase64String(value);
            }
        }

        public String Getcarddata_pkcs1_support()
        {
            return this.carddata_pkcs1_support;
        }

        public void Setcarddata_pkcs1_support(byte[] value)
        {
            if (value != null)
            {
                this.carddata_pkcs1_support = Convert.ToBase64String(value);
            }
        }

        public String Getcarddata_key_exchange_version()
        {
            return this.carddata_key_exchange_version;
        }

        public void Setcarddata_key_exchange_version(byte[] value)
        {
            if (value != null)
            {
                this.carddata_key_exchange_version = Convert.ToBase64String(value);
            }
        }

        public String Getcarddata_appl_lifecycle()
        {
            return this.carddata_appl_lifecycle;
        }

        public void Setcarddata_appl_lifecycle(byte[] value)
        {
            if (value != null)
            {
                this.carddata_appl_lifecycle = Convert.ToBase64String(value);
            }
        }


    }
}
