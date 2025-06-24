//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com
//********************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
//The below is framwework is 4.0.0.0
using System.Security.Cryptography;
namespace PTX.GO
{

    #region cryptogarphy and security
    public class PTXSecurity
    {
        //Get Nonce VIA API from PTXAPP, this needs to include the ClientIDSha256HashHash

        private static string PTXNonceSha256Hash = "This Is PTX And We Want To Take On The World!";

        


        #region cryptogarphy  

        /// <summary>
        /// Encrypts the given URL by encrypting the parameters part of the URL using a randomly generated key.
        /// </summary>
        /// <param name="originalUrl">The original URL to be encrypted.</param>
        /// <returns>The encrypted URL.</returns>
        private static string EncryptURL(string originalUrl)
        {
            // Split the URL into the main URL and the parameters part
            string[] urlParts = originalUrl.Split('?');
            string url = urlParts[0];
            string parameters = urlParts.Length > 1 ? urlParts[1] : string.Empty;

            // Generate a random key
            byte[] key = GenerateRandomKey();

            // Encrypt the parameters using the key
            string encryptedParameters = EncryptString(parameters, key);

            // Combine the encrypted parameters with the main URL
            string encryptedUrl = url + "?" + encryptedParameters;

            return encryptedUrl;
        }

        /// <summary>
        /// Generates a random encryption key using the AES algorithm.
        /// </summary>
        /// <returns>A byte array representing the generated key.</returns>
        private static byte[] GenerateRandomKey()
        {
            using (var aes = Aes.Create())
            {
                // Generate a random key using the AES algorithm
                aes.GenerateKey();

                // Return the generated key
                return aes.Key;
            }
        }



        /// <summary>
        /// Encrypts the given string message using the provided key.
        /// </summary>
        /// <param name="message">The message to be encrypted.</param>
        /// <param name="key">The encryption key.</param>
        /// <returns>The encrypted string.</returns>
        private static string EncryptString(string message, byte[] key)
        {
            // Convert the message to bytes using UTF-8 encoding
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (var aes = Aes.Create())
            {
                // Set the encryption key
                aes.Key = key;

                // Generate a random initialization vector (IV)
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor())
                {
                    // Encrypt the message bytes
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(messageBytes, 0, messageBytes.Length);

                    // Prepend IV to the encrypted data for later use during decryption
                    byte[] combinedBytes = new byte[aes.IV.Length + encryptedBytes.Length];
                    Array.Copy(aes.IV, combinedBytes, aes.IV.Length);
                    Array.Copy(encryptedBytes, 0, combinedBytes, aes.IV.Length, encryptedBytes.Length);

                    // Convert the combined bytes to a Base64-encoded string
                    return Convert.ToBase64String(combinedBytes);
                }
            }
        }

        /// <summary>
        /// Decrypts the given encrypted message using the provided key.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message to be decrypted.</param>
        /// <param name="key">The decryption key.</param>
        /// <returns>The decrypted string.</returns>
        private static string DecryptString(string encryptedMessage, byte[] key)
        {
            // Convert the encrypted message from Base64 to bytes
            byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);

            using (var aes = Aes.Create())
            {
                // Set the decryption key
                aes.Key = key;

                // Extract the IV from the encrypted bytes
                byte[] iv = new byte[aes.IV.Length];
                Array.Copy(encryptedBytes, iv, aes.IV.Length);

                using (var decryptor = aes.CreateDecryptor(key, iv))
                {
                    // Decrypt the encrypted bytes (excluding the IV)
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, aes.IV.Length, encryptedBytes.Length - aes.IV.Length);

                    // Convert the decrypted bytes to a string using UTF-8 encoding
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }


        public string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            { throw new ArgumentNullException("cipherText"); return "Fail "; }
            if (Key == null || Key.Length <= 0)
            { throw new ArgumentNullException("Key"); return "Fail "; }
            if (IV == null || IV.Length <= 0)
            { throw new ArgumentNullException("IV"); return "Fail "; }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }





        /// <summary>
        /// Code is copied from CalxCloudSecurity.cs in PTX solution
        /// NOTE : This SHOULD ACTUALLY BE AN API"
        /// This  section is used to encrypt a value to be looked up on the DB
        /// eg to look up a name+DOB+NINO, concatenate and then encrypt them, the cirrespongon value is stored on the DB
        /// Retruns 256 byte encryted string
        /// /// https://rpmitconsulting-my.sharepoint.com/personal/rob_mann_rpmitconsulting_com/Documents/RPMITConsulting/Documents
        /// </summary>
        /// <param name="inValueToBeEncypted"></param>
        /// <returns></returns>

        public string ComputeSha256Hash(string inValueToBeEncypted)
        {
            //Add Nonce

            inValueToBeEncypted = PTXNonceSha256Hash + inValueToBeEncypted;

            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inValueToBeEncypted));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
        }

        /// <summary>
        /// Used to encrypt and string normally to encypt the request from http://Base.com/api/?ENCRPT
        /// </summary>
        /// <param name="Encryptval"></param>
        /// <returns>Encypted String</returns>
        public string Encryptword(string Encryptval)
        {

            byte[] SrctArray;
            byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(Encryptval);
            SrctArray = UTF8Encoding.UTF8.GetBytes(PTXNonceSha256Hash);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
            SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(PTXNonceSha256Hash));
            objcrpt.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateEncryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);
            objt.Clear();
            return Convert.ToBase64String(resArray, 0, resArray.Length);

            /*
             * AesManaged aes = new AesManaged();
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
            Encryptword = StringCipher.Encrypt(Encryptval, PTXNonceSha256Hash);
            */

        }
        /// <summary>
        /// Used to decrypt a string 
        /// </summary>
        /// <param name="DecryptText"></param>
        /// <returns>Decypted String</returns>
        public string Decryptword(string DecryptText)
        {
            byte[] SrctArray;
            byte[] DrctArray = Convert.FromBase64String(DecryptText);
            SrctArray = UTF8Encoding.UTF8.GetBytes(PTXNonceSha256Hash);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();
            SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(PTXNonceSha256Hash));
            objmdcript.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            //There is an issue in PTX search for ISS12345
            ICryptoTransform crptotrns = objt.CreateDecryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);
            objt.Clear();
            return UTF8Encoding.UTF8.GetString(resArray);
        }

        #endregion

        #region PTXRSAEncrpt(string inValueToBeEncypted)
        public void PTXRSAEncrpt(string inValueToBeEncypted)
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/security/encrypting-data

            //inValueToBeEncypted = PTXnonce + inValueToBeEncypted;

            //byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inValueToBeEncypted));
        }

        #endregion

    }
    #endregion

    #region Report a bug

    public class PTXReport
    {
        /// <summary>
        /// This class is used to report a bug via a web page.
        /// The process will be 
        /// 1 - Back - Collate as New List (paid values) PageName, FunctionName, Now(), Version(),
        ///                    All Values and Names of objects on page
        ///                    Creat JSON object
        /// 2 - USER : String of what issue was                   
        /// 3 - Create Email to send or send one behind the schenes                    
        /// </summary>


        internal List<ReportItem> ReportList { get; set; }

        /// <summary>
        /// This is the return if required to a web page
        /// </summary>
        public string JSONReport { get; set; }

        public bool Default_PageDevMode { get; }

        /// <summary>
        /// Defines is message has bee sent successfully (True)
        /// </summary>
        public bool MessageSuccess { get; set; }

        //Default constructor, instantiate objects




     






        /// <summary>
        /// ReportItem class defined the structure of this lis
        /// </summary>
        internal class ReportItem
        {
            // obviously you find meaningful names of the 2 properties

            public string Item { get; set; }
            public string Description { get; set; }

            /// <summary>
            /// Constructor for Report item
            /// </summary>
            /// <param name="myItem"></param>
            /// <param name="myDescription"></param>
            internal ReportItem(string myItem, string myDescription)
            {
                Item = myItem;
                Description = myDescription;
            }


        }




    }

    #endregion


  

    public class PTXGOWebHelper
    {

        //This class is used to help with some of the generic UI on the web site

        //Static strings
       
        
        public string OutputPrefix { get; } = "out";
        public string InputPrefix { get; } = "in";
        public string HTMLPrefix { get; } = "HTML";
        public static object PTXSecurity { get; internal set; }

        //Lists used in drop downs
        public List<string> YMDList = new List<string>() { "Years", "Months", "Days" };
        
        public List<string> int0to12List = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
        public List<string> int1to12List = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        public List<string> int0to5List = new List<string>() { "0", "1", "2", "3", "4", "5"};
        public List<string> int0to20List = new List<string>() { "0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20" };
        public List<string> int0to120List = new List<string>() {"0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59","60","61","62","63","64","65","66","67","68","69","70","71","72","73","74","75","76","77","78","79","80","81","82","83","84","85","86","87","88","89","90","91","92","93","94","95","96","97","98","99","100","101","102","103","104","105","106","107","108","109","110","111","112","113","114","115","116","117","118","119","120"};
        public List<string> int1950to2025List = new List<string>(){"1950","1951","1952","1953","1954","1955","1956","1957","1958","1959","1960","1961","1962","1963","1964","1965","1966","1967","1968","1969","1970","1971","1972","1973","1974","1975","1976","1977","1978","1979","1980","1981","1982","1983","1984","1985","1986","1987","1988","1989","1990","1991","1992","1993","1994","1995","1996","1997","1998","1999","2000","2001","2002","2003","2004","2005","2006","2007","2008","2009","2010","2011","2012","2013","2014","2015","2016","2017","2018","2019","2020","2021","2022","2023","2024","2025"};
        public List<string> int1950to2020List = new List<string>() { "1950", "1951", "1952", "1953", "1954", "1955", "1956", "1957", "1958", "1959", "1960", "1961", "1962", "1963", "1964", "1965", "1966", "1967", "1968", "1969", "1970", "1971", "1972", "1973", "1974", "1975", "1976", "1977", "1978", "1979", "1980", "1981", "1982", "1983", "1984", "1985", "1986", "1987", "1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997", "1998", "1999", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020" };


        public List<string> GenderList = new List<string>() { "Male", "Female" };
        public List<string> DropDownDummy = new List<string>() { "Dummy" };
        public List<string> Mort1dList = new List<string>() { "PMA92_B_1977", "CFA00LC Floor of 0pc", "AM80", "CMA00LCFloorof0_B_1977", "PNMA00", "PNFA00", "All1", "AllZero", };


        //Allowable tyeps of objects
        public string PTXObjType_DropDown { get; } = "DropDown";
        public string PTXObjType_TextBox { get; } = "TextBox";
        public string PTXObjType_DatePicker { get; } = "DatePicker";
        public string PTXObjType_Label { get; } = "Label";
        public string PTXObjType_None { get; } = "None";
        public string PTXObjType_HTMLLink { get; } = "HTMLLink";
        public string PTXObjType_Mort1DTable { get; } = "Mort1DTable";
        

        //PensionsDashboards
        public List<string> PDPRefNumberList = new List<string>()
        {
            //"1.001","1.002","1.003","1.004","1.005","1.006","1.007","1.008","1.009","1.01","1.011","1.012","1.013","1.014","1.015","1.016","1.017","1.018","1.019","1.02","1.021","2.001","2.002","2.003","2.004","2.005","2.006","2.007","2.008","2.101","2.102","2.103","2.104","2.105","2.106","2.107","2.108","2.109","2.11","2.111","2.112","2.113","2.114","2.201","2.202","2.203","2.301","2.302","2.303","2.304","2.305","2.306","2.307","2.308","2.401","2.402","2.403","2.404","2.405","2.406","2.407","2.501","2.502","2.503","2.504"
            "1.001-Given name","1.002-Name","1.003-Date of birth","1.004-NI number","1.005-NI number assertion","1.006-Alternate name type","1.007-Alternate name","1.008-Alternate name assertion","1.009-Address type","1.01-Address line 1","1.011-Address line 2","1.012-Address line 3","1.013-Address line 4","1.014-Address line 5","1.015-Postcode","1.016-Country code","1.017-Address assertion","1.018-Email address","1.019-Email assertion","1.02-Mobile number","1.021-Mobile assertion","2.001-Pension reference","2.002-Pension name","2.003-Pension type","2.004-Pension origin","2.005-Pension status","2.006-Pension start date","2.007-Pension retirement date","2.008-Pension link","2.101-Administrator reference","2.102-Administrator name","2.103-Admin contact preference","2.104-Administrator URL","2.105-Administrator email","2.106-Administrator phone number","2.107-Administrator phone number type","2.108-Administrator postal name","2.109-Administrator address line 1","2.11-Address line 2","2.111-Address line 3","2.112-Address line 4","2.113-Address line 5","2.114-Postcode","2.201-Employer name","2.202-Employment start date","2.203-Employment end date","2.301-ERI type","2.302-ERI basis","2.303-ERI calculation date","2.304-ERI payable date","2.305-ERI amount","2.306-ERI pot","2.307-ERI safeguarded benefits","2.308-ERI unavailable","2.401-Accrued type","2.402-Accrued amount type","2.404-Accrued payable date","2.405-Accrued amount","2.406-Accrued safeguarded benefits","2.407-Accrued unavailable","2.501-Costs and charges","2.502-SIP URL","2.503-Implementation statement URL","2.504-Annual report URL"
        };

        /// <summary>
        /// List of all Live microservices
        /// FUTURE read in from DB
        /// </summary>
        /// </summary>
        public List<string> MicroserviceList = new List<string>()
        {
            "FuncAgeComp","FuncServComp","FuncGetAct1DTable","FuncVN","FuncDOND","FuncLONL","FuncASL","FuncANC","FuncATP","FuncLTA","FuncRPI_ChangeOver12Months","FuncGMPFixedRate","FuncGetAct1DTableChart"
        };


        public List<string> PTX_PDPSystemNameList = new List<string>()
        {
            "PTX_GivenName","PTX_Name","PTX_DOB","PTX_NINO","PTX_NINOAssertion","PTX_AlternateNameType","PTX_AlternateName","PTX_AlternateNameAssertion","PTX_AddressType","PTX_AddressLine1","PTX_AddressLine2","PTX_AddressLine3","PTX_AddressLine4","PTX_AddressLine5","PTX_Postcode","PTX_CountryCodeISO","PTX_AddressAssertion","PTX_Email","PTX_EmailAssertion","PTX_MobileNumber","PTX_MobileAssertion","PTX_PensionReference","PTX_PensionName","PTX_PensionType","PTX_PensionOrigin","PTX_PensionStatus","PTX_PensionStartDate","PTX_PensionRetirementDate","PTX_PensionLink","PTX_AdministratorReference_UID","PTX_AdministratorName","PTX_AdminContactPreference","PTX_AdministratorURL","PTX_AdministratorEmail","PTX_AdministratorPhoneNumber","PTX_AdministratorPhoneNumberType","PTX_AdministratorPostalName","PTX_AdministratorAddressLine1","PTX_AdministratorAddressLine2","PTX_AdministratorAddressLine3","PTX_AdministratorAddressLine4","PTX_AdministratorAddressLine5","PTX_AdministratorPostcode","PTX_EmployerName","PTX_EmploymentStartDate","PTX_EmploymentEndDate","PTX_ERIType","PTX_ERIBasis","PTX_ERICalcDate","PTX_ERIPayableDate","PTX_ERIAmount","PTX_ERIPot","PTX_ERISafeguardedBenefits","PTX_ERIUnavailable","PTX_AccruedType","PTX_AccruedAmountType","PTX_AccruedPayableDate","PTX_AccruedAmount","PTX_AccruedSafeguardedBenefits","PTX_AccruedUnavailable","PTX_CostsAndCharges","PTX_SIPURL","PTX_ImplementationStatementURL","PTX_AnnualReportURL"

        };
        public List<string> PDPLevel1List = new List<string>()
        {
            "1.### Find Data",
            "2.### View"
        };
        public List<string> PDPLevel2List = new List<string>()
        {
            "1.0## Find Data",
            "2.0## Pension Arrangement Data",
            "2.1## Pension Administrator Details",
            "2.2## Employer Details",
            "2.3## Estimated Retirement Income (ERI) Data",
            "2.4## Accrued Pension Data",
            "2.5## Additional Data (Signposts)"
        };

    

    }

}




