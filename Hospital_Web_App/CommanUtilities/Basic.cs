using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanUtilities
{
    public class Basic
    {
        public Basic()
        {
            //  _FromDate = Program.FromDate;
            //_ToDate = Program.ToDate;
        }

        private DateTime _FromDate;
        private DateTime _ToDate;
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        public String GetReportDateRange()
        {
            return "From " + _FromDate.ToShortDateString() + " To " + _ToDate.ToShortDateString();
        }

        //public int SetDropDown(ComboBox mComboBox, String FindValue)
        //{
        //    int ReturnValue = -1;
        //    for (int i = 0; i < mComboBox.Items.Count; i++)
        //    {
        //        mComboBox.SelectedIndex = i;
        //        ReturnValue = i;
        //        if (mComboBox.SelectedValue.ToString() == FindValue)
        //        {
        //            break;
        //        }
        //    }
        //    return ReturnValue;

        //}
        //public String s = System.Configuration.ConnectionStringSetting
        //public String ConnString = "data source=" + Program.Server + ";initial catalog = " + Program.DataBaseName + ";user id=sa;password = smart;";
        //public void Basic1()
        //{
        //    // Get the application configuration file.
        //    System.Configuration.Configuration config =ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    // Get the conectionStrings section.


        //    ConnectionStringsSection csSection =config.ConnectionStrings;
        //    for (int i = 0; i <ConfigurationManager.ConnectionStrings.Count; i++)
        //    {
        //        ConnectionStringSettings cs =csSection.ConnectionStrings[i];
        //        Console.WriteLine("  Connection String: \"{0}\"",cs.ConnectionString);
        //        ConnString=cs.ConnectionString;
        //    }


        //}

        //public int GetLoging(String UserName, String Password, String CompanyCode)
        //{
        //    SqlConnection Connnection;
        //    int userid = -1;
        //    try
        //    {
        //        String CommandString = "select userid,passwords,username,rights from usermaster where username='" + UserName + "' and passwords = '" + Password + "' and companycode='" + CompanyCode + "'";
        //        Connnection = new SqlConnection(ConnString);

        //        SqlCommand command = new SqlCommand(CommandString, Connnection);
        //        Connnection.Open();
        //        SqlDataReader Datareader = command.ExecuteReader();
        //        if (Datareader.HasRows)
        //        {
        //            Datareader.Read();
        //            userid = Convert.ToInt16(Datareader["userid"]);
        //            Program.Rights = Datareader["rights"].ToString();
        //        }
        //        Datareader.Close();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return userid;
        //}

        //public int GetCompanyDetails(String CompanyCode)
        //{
        //    SqlConnection Connnection;
        //    try
        //    {
        //        String CommandString = "select ClientId,ProductId from companymaster where  companycode='" + CompanyCode + "'";
        //        Connnection = new SqlConnection(ConnString);

        //        SqlCommand command = new SqlCommand(CommandString, Connnection);
        //        Connnection.Open();
        //        SqlDataReader Datareader = command.ExecuteReader();
        //        if (Datareader.HasRows)
        //        {
        //            Datareader.Read();
        //            if (Convert.IsDBNull(Datareader["ProductId"]) || Convert.IsDBNull(Datareader["ClientId"]))
        //            {

        //                return -1;
        //            }
        //            Program.ProductId = Convert.ToInt32(Datareader["ProductId"]);
        //            Program.ClientId = Convert.ToInt32(Datareader["ClientId"]); ;
        //        }
        //        Datareader.Close();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return 1;
        //}

        #region Key Coding
        public int GetMax(String TableName, String FieldName)
        {
            // SqlConnection Connnection;
            int i;
            String commandString;
            MSAccessDataUtility objDataUtility = new MSAccessDataUtility();
            i = 0;
            try
            {
                commandString = "select  max(" + FieldName + ") from " + TableName;
                i = objDataUtility.GetScalarValue(commandString);
            }
            catch (Exception Ex)
            {
                throw Ex;
                //MessageBox.Show(Ex.Message);
            }
            return i;
        }

        //public int GetMax(String TableName, String FieldName, String WhereCondition)
        //{
        //    //CRFNO(15#),SRFSR(bigint)
        //   // SqlConnection Connnection;
        //    int i;
        //    String commandString;
        //    i = 0;
        //    try
        //    {
        //        if (WhereCondition.Length > 0)
        //        {
        //            commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where " + WhereCondition;
        //        }
        //        else
        //        {
        //            commandString = "select max(" + FieldName + ") as maxid from " + TableName;
        //        }
        //        i = ExecuteQueryString(commandString);
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public int GetMax(String TableName, String FieldName, String WhereCondition, bool WithDivID)
        //{
        //    //CompanyID (3#), DivID (3#), Fyear (4#), Srno (5#)
        //    //CompanyID (3#), Fyear (4#), Srno (5#)
        //    if (WhereCondition.Length > 0)
        //        WhereCondition = " and " + WhereCondition;
        //   // SqlConnection Connnection;
        //    LogDetails logdetails = new LogDetails();
        //    int i;
        //    String commandString;
        //    i = 0;
        //    try
        //    {
        //        if (WithDivID ==true)
        //        {
        //            commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and divid='" + logdetails.CurrentDivID + "' and fyear=" + logdetails.CurrentFinancialYear + " "+ WhereCondition;
        //        }
        //        else
        //        {
        //            commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and fyear=" + logdetails.CurrentFinancialYear + " " + WhereCondition;
        //        }
        //        i = ExecuteQueryString(commandString);
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public int GetMax(String TableName, String FieldName, bool WithDivID)
        //{
        //    //CompanyID (3#), DivID (3#), Fyear (4#), Srno (5#)
        //    //CompanyID (3#), Fyear (4#), Srno (5#)

        //    // SqlConnection Connnection;
        //    LogDetails logdetails = new LogDetails();
        //    int i;
        //    String commandString;
        //    i = 0;
        //    try
        //    {
        //        if (WithDivID == true)
        //        {
        //            commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and divid='" + logdetails.CurrentDivID + "' and fyear=" + logdetails.CurrentFinancialYear;
        //        }
        //        else
        //        {
        //            commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and fyear=" + logdetails.CurrentFinancialYear;
        //        }
        //        i = ExecuteQueryString(commandString);
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public int GetMax(String TableName, String FieldName,DateTime datetime)
        //{
        //    //SqlCommand command = new SqlCommand("select sum(intresttdsamount) as intTotal from promissorey where browcode='" + BorrowerCodetextBox.Text + "' and landercode='" + LenderCodetextBox.Text + "' and permotDate<@dt", Connnection);
        //    Basic basic = new Basic();
        //    SqlConnection Connnection = new SqlConnection(basic.ConnString);
        //    int i = 0;
        //    try
        //    {

        //        SqlCommand command = new SqlCommand("select max(" + FieldName + ") as maxid from " + TableName + " Where LotDate>=@dt", Connnection);
        //        SqlParameter Sp = new SqlParameter("dt", DbType.Date);
        //        Sp.Value = datetime.Date;
        //        command.Parameters.Add(Sp);
        //        Connnection.Open();
        //        SqlDataReader Datareader = command.ExecuteReader();
        //        if (Datareader.HasRows)
        //        {
        //            while (Datareader.Read())
        //            {
        //                if (!(Convert.IsDBNull(Datareader[0]) == true))
        //                    i = Convert.ToInt32(Datareader[0]);
        //            }
        //        }
        //        Datareader.Close();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Connnection.Close();
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public int GetMax(String TableName, String FieldName, String WhereCondition, bool WithDivID)
        //{
        //    //CompanyID (3#), DivID (3#), Fyear (4#), Srno (5#)
        //    //CompanyID (3#), Fyear (4#), Srno (5#)
        //                LogDetails logdetails = new LogDetails();
        //    int i;
        //    String commandString;
        //    i = 0;
        //    try
        //    {
        //        if (WhereCondition.Length > 0)
        //        {
        //            if (WithDivID == true)
        //            {
        //                commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and divid='" + logdetails.CurrentDivID + "' and fyear=" + logdetails.CurrentFinancialYear + " and " + WhereCondition;
        //            }
        //            else
        //            {
        //                commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and fyear=" + logdetails.CurrentFinancialYear;
        //            }
        //        }
        //        else
        //        {
        //            if (WithDivID == true)
        //            {
        //                commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and divid='" + logdetails.CurrentDivID + "' and fyear=" + logdetails.CurrentFinancialYear;
        //            }
        //            else
        //            {
        //                commandString = "select max(" + FieldName + ") as maxid from " + TableName + " Where CompanyCode='" + logdetails.CurrentCompanyCode + "' and fyear=" + logdetails.CurrentFinancialYear;
        //            }
        //        }

        //        i = ExecuteQueryString(commandString);

        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public String GetKey(int Srno,Char Prefix,String Pad)
        //{
        //    String s="";
        //    try
        //    {
        //        s = Srno.ToString();
        //        if(Prefix=='~')
        //            s = Pad.Substring(0, (Pad.Length - s.Length)) + s;
        //        else
        //            s =Prefix + Pad.Substring(0, (Pad.Length - s.Length)) + s;
        //    }
        //    catch (Exception Ex)
        //    {
        //       // MessageBox.Show(Ex.Message);
        //        return s;
        //    }
        //    return s;
        //}

        public String GetKey(int Srno)
        {

            //FOR ALL VOUCHER CRFNO WILL CONTINUE AS FINANCIAL YEAR


            String s, s1;
            s = ""; s1 = "";
            //  LogDetails logdetails = new LogDetails();
            try
            {
                s = Srno.ToString();
                s1 = LogDetails.CurrentFinancialYear.ToString();
                s = LogDetails.CurrentCompanyCode + LogDetails.CurrentDivID + s1 + "0000".Substring(0, (5 - s.Length)) + s;
            }
            catch (Exception Ex)
            {
                // MessageBox.Show(Ex.Message);
                return s;
            }
            return s;
        }

        public String GetKey(int Srno, Char ch)
        {

            //    Sale, Purchasse, Process, Ready Stock 
            //    CRFNO (15#)  = CompanyID (3#) + DivID (3#) + Fyear(4#)+Srno(5#)


            //    Ledger, Group
            //    CRFNO(12#)  = CompanyID (3#), Fyear (4#), Srno (5#)

            /*
                CRFNo Index Key
                I-PURCHASE;
             *  S-SALE CASH 
             *  H-PCR
             *  C-PAYMENT/RECEIPT
             *  Q
             */

            //
            /* L-Ledger
             * G-Group
             * P-Party
             */

            String s, s1;
            s = ""; s1 = "";
            // LogDetails logdetails = new LogDetails();
            try
            {
                s = Srno.ToString();
                s1 = LogDetails.CurrentFinancialYear.ToString();
                switch (ch)
                {
                    case 'G':
                    case 'L':
                    case 'I':
                    case 'H':
                    case 'M':
                    case 'S':
                    case 'C':
                    case 'R':
                    case 'K':
                    case 'Q':
                    case 'E':
                    case 'T':
                    case 'A':
                    case 'B':
                        s = LogDetails.CurrentCompanyCode + s1 + ch + "0000".Substring(0, (5 - s.Length)) + s;
                        break;
                    case 'P':
                        s = LogDetails.CurrentCompanyCode.Substring(1) + "P000".Substring(0, (4 - s.Length)) + s;
                        break;
                    default:
                        s = LogDetails.CurrentCompanyCode + s1 + "0000".Substring(0, (5 - s.Length)) + s;
                        break;
                }
            }
            catch (Exception Ex)
            {
                // MessageBox.Show(Ex.Message);
                return s;
            }
            return s;

        }

        //public String GetKey(int Srno, Char ch, DateTime lotdate)
        //{
        //    //   for  Lotnot only

        //    String s, s1,day,month;
        //    s = ""; s1 = "";
        //    LogDetails logdetails = new LogDetails();
        //    try
        //    {
        //        s = Srno.ToString();
        //        s1 = logdetails.CurrentFinancialYear.ToString();
        //        switch (ch)
        //        {
        //            case 'T':
        //               // day = lotdate.Day.ToString("0#");
        //               // month =lotdate.Month.ToString("0#");
        //                s = logdetails.CurrentCompanyCode + "/" + lotdate.Day.ToString("0#") + lotdate.Month.ToString("0#") + lotdate.Year.ToString().Substring(2, 2) + "/" + s1 + "/00".Substring(0, (4 - s.Length)) + s;
        //                break;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //      //  MessageBox.Show(Ex.Message);
        //        return s;
        //    }
        //    return s;
        //}

        #endregion

        //#region Query Executions

        //int ExecuteQueryString(String CommandString)
        //{
        //    //CRFNO(15#),SRFSR(bigint)
        //    SqlConnection Connnection;
        //    int i = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand(CommandString, Connnection);
        //        Connnection.Open();
        //        SqlDataReader Datareader = command.ExecuteReader();
        //        while (Datareader.Read())
        //        {
        //            if (Convert.IsDBNull(Datareader[0]) == true)
        //            {
        //            }
        //            else
        //                i = Convert.ToInt32(Datareader[0]);
        //        }
        //        Datareader.Close();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public String ExecuteQueryGetSingleStringValue(String CommandString)
        //{
        //    SqlConnection Connnection;
        //    String ReturnValue = "";
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand(CommandString, Connnection);
        //        Connnection.Open();
        //        SqlDataReader Datareader = command.ExecuteReader();
        //        if (Datareader.HasRows)
        //        {
        //            Datareader.Read();
        //            ReturnValue = Datareader[0].ToString();
        //        }
        //        Datareader.Close();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int ExecuteQuery(String CommandString)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand(CommandString, Connnection);
        //        Connnection.Open();
        //        ReturnValue=  command.ExecuteNonQuery();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int ExecuteQuery(String StoreProcedureName,CommandType QryType)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand(StoreProcedureName,Connnection);
        //        command.CommandType = QryType;
        //        Connnection.Open();
        //        ReturnValue = command.ExecuteNonQuery();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int ExecuteQuery(String StoreProcedureName, CommandType QryType,int Total)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand(StoreProcedureName, Connnection);
        //        command.CommandType = QryType;

        //        SqlParameter CompanyCode = new SqlParameter("@companycode", SqlDbType.VarChar, 3);
        //        CompanyCode.Value = Program.CurrentCompanyCode;
        //        command.Parameters.Add(CompanyCode);

        //        SqlParameter Fyear = new SqlParameter("@fyear", SqlDbType.Int);
        //        Fyear.Value = Program.CurrentFinancialYear;
        //        command.Parameters.Add(Fyear);

        //        Connnection.Open();
        //        ReturnValue = command.ExecuteNonQuery();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int ExecuteAccounts(String StoreProcedure , string CompanyCode, int Fyear)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = Connnection;
        //        command.CommandText = StoreProcedure;// "Default_Ledger";
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlParameter Fyearp = new SqlParameter("@fyear", SqlDbType.Int);
        //        Fyearp.Value = Fyear;
        //        command.Parameters.Add(Fyearp);

        //        SqlParameter CompanyCodep = new SqlParameter("@CompanyCode", SqlDbType.VarChar, 3);
        //        CompanyCodep.Value = CompanyCode;
        //        command.Parameters.Add(CompanyCodep);

        //        Connnection.Open();
        //        ReturnValue = command.ExecuteNonQuery();
        //        Connnection.Close();
        //        ReturnValue = 1;

        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int ExecuteSP(String StoreProcedureName,String ComanyCode, int Fyear, int FromFyear)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand(StoreProcedureName, Connnection);
        //        command.CommandType = CommandType.StoredProcedure ;

        //        SqlParameter companycodep = new SqlParameter("companycode", SqlDbType.VarChar, 3);
        //        companycodep.Value = ComanyCode;
        //        command.Parameters.Add(companycodep);

        //        SqlParameter fyearp = new SqlParameter("Fyear", SqlDbType.Int);
        //        fyearp.Value = Fyear;
        //        command.Parameters.Add(fyearp);

        //        SqlParameter fromfyearp = new SqlParameter("FromFyear", SqlDbType.Int);
        //        fromfyearp.Value = FromFyear;
        //        command.Parameters.Add(fromfyearp);

        //        Connnection.Open();
        //        ReturnValue = command.ExecuteNonQuery();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //#endregion

        //#region Basic Insert Updatge Delete

        //public int InsertFyear(int Fyear)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = Connnection;
        //        command.CommandText = "Default_FyearMaster";
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlParameter Fyearp = new SqlParameter("@fyear", SqlDbType.Int);
        //        Fyearp.Value = Fyear;
        //        command.Parameters.Add(Fyearp);
        //        Connnection.Open();
        //        ReturnValue = command.ExecuteNonQuery();
        //        Connnection.Close();
        //        ReturnValue = 1;

        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int InsertUser(String CompanyCode)
        //{
        //    SqlConnection Connnection;
        //    int ReturnValue = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = Connnection;
        //        command.CommandText = "Default_User";
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlParameter CompanyCodep = new SqlParameter("@CompanyCode", SqlDbType.VarChar, 3);
        //        CompanyCodep.Value = CompanyCode;
        //        command.Parameters.Add(CompanyCodep);

        //        SqlParameter Useridp = new SqlParameter("@Userid", SqlDbType.Int);
        //        Useridp.Value = GetMax("usermaster","UserId")+1;
        //        command.Parameters.Add(Useridp);
        //        Connnection.Open();
        //        ReturnValue = command.ExecuteNonQuery();
        //        Connnection.Close();
        //        ReturnValue = 1;

        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return ReturnValue;
        //}

        //public int InsertLedger(string CompanyCode, int Fyear)
        //{
        //    ExecuteAccounts("Default_Ledger", CompanyCode, Fyear);
        //    return 1;
        //}

        //public int InsertGroup(string CompanyCode, int Fyear)
        //{
        //    ExecuteAccounts("Default_Group", CompanyCode, Fyear);
        //    return 1;
        //}

        //public int DeleteCompany(string CompanyCode, int Fyear)
        //{
        //    ExecuteAccounts("Delete_Company", CompanyCode, Fyear);
        //    return 1;
        //}

        //public int DeleteRecords(String TableName)
        //{
        //    int i = DeleteRec(TableName, "");
        //    return i;

        //}

        //public int DeleteRecords(String TableName, String Condition)
        //{
        //    int i = DeleteRec(TableName, Condition);
        //    return i;

        //}

        //private int DeleteRec(String TableName, String Condition)
        //{
        //    SqlConnection Connnection;
        //    int i = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        if (Condition != "")
        //            Condition = " Where " + Condition;
        //        SqlCommand command = new SqlCommand("delete from " + TableName + Condition  , Connnection);
        //        Connnection.Open();
        //        i=command.ExecuteNonQuery();
        //        command.Dispose();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    return i;
        //}

        //public string UpdateParty(String Code)
        //{
        //    String Name = UpdateParty("PartyName", "code", "Partymaster", Code);
        //    return Name;
        //}

        //public string UpdateParty(String FromTable,String Code)
        //{
        //    String SName = "";
        //    if (FromTable.ToUpper() == "LEDGER")
        //    {
        //        SName=UpdateParty("LNAME", "LCode", FromTable, Code);
        //    }
        //    if (FromTable.ToUpper() == "DIVISIONMASTER")
        //    {
        //        SName = UpdateParty("DIVNAME", "DIVID", FromTable, Code);
        //    }
        //    return SName;
        //}

        //public string UpdateParty(String NameField,String CodeField, String TableName, String Code)
        //{

        //    Basic basic = new Basic();
        //    SqlConnection Connnection1;
        //    Connnection1 = new SqlConnection(basic.ConnString);
        //    string partyname = "";
        //    try
        //    {

        //        SqlCommand command = new SqlCommand("select * from " + TableName + " where " + CodeField + "='" + Code + "'", Connnection1);
        //        Connnection1.Open();
        //        SqlDataReader Datareader = command.ExecuteReader();
        //        if (Datareader.HasRows)
        //        {
        //            while (Datareader.Read())
        //            {
        //                if (Convert.IsDBNull(Datareader[NameField])==false)
        //                    partyname = Convert.ToString(Datareader[NameField]);
        //            }
        //        }
        //        Datareader.Close();
        //        Connnection1.Close();
        //    }
        //    catch
        //    {
        //        Connnection1.Close();
        //    }
        //    return partyname;
        //}

        //public string UpdateItem(String ItemCode)
        //{
        //    return UpdateParty("itemname", "itemcode", "item", ItemCode);
        //}

        //public void updateClosingBalance(String CompanyCode, int Fyear)
        //{
        //    SqlConnection Connnection;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = Connnection;
        //        command.CommandText = "Update_ClosingBalance";
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlParameter CompanyCodep = new SqlParameter("@CompanyCode", SqlDbType.VarChar, 3);
        //        CompanyCodep.Value = CompanyCode;
        //        command.Parameters.Add(CompanyCodep);

        //        SqlParameter Fyearp = new SqlParameter("@fyear", SqlDbType.Int);
        //        Fyearp.Value = Fyear;
        //        command.Parameters.Add(Fyearp);

        //        Connnection.Open();
        //        int i = command.ExecuteNonQuery();
        //        Connnection.Close();

        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //}

        //public void TransClosingBalance(String CompanyCode, int FromFyear, int ToFyear)
        //{
        //    SqlConnection Connnection;
        //    try
        //    {
        //        Connnection = new SqlConnection(ConnString);
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = Connnection;
        //        command.CommandText = "Update_TranfClosingBalance";
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlParameter CompanyCodep = new SqlParameter("@CompanyCode", SqlDbType.VarChar, 3);
        //        CompanyCodep.Value = CompanyCode;
        //        command.Parameters.Add(CompanyCodep);

        //        SqlParameter FromFyearp = new SqlParameter("@fromfyear", SqlDbType.Int);
        //        FromFyearp.Value = FromFyear;
        //        command.Parameters.Add(FromFyearp);

        //        SqlParameter ToFyearp = new SqlParameter("@tofyear", SqlDbType.Int);
        //        ToFyearp.Value = ToFyear;
        //        command.Parameters.Add(ToFyearp);

        //        Connnection.Open();
        //        int i = command.ExecuteNonQuery();
        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //}

        //public void TransClosingBalanceToParty(int ToFyear)
        //{

        //    SqlConnection Connnection;
        //    Basic basic = new Basic();
        //    int i = 0;
        //    try
        //    {
        //        Connnection = new SqlConnection(basic.ConnString);
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = Connnection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Update_TranfClosingBalanceToParty";
        //        Connnection.Open();

        //        SqlParameter pCompanyCode = new SqlParameter("@companycode", SqlDbType.VarChar, 3);
        //        pCompanyCode.Value = Program.CurrentCompanyCode;
        //        command.Parameters.Add(pCompanyCode);

        //        SqlParameter pFyear = new SqlParameter("@fromfyear", SqlDbType.Int);
        //        pFyear.Value = Program.CurrentFinancialYear;
        //        command.Parameters.Add(pFyear);

        //        SqlParameter pTFyear = new SqlParameter("@ToFyear", SqlDbType.Int);
        //        pTFyear.Value = ToFyear;
        //        command.Parameters.Add(pTFyear);

        //        int g = command.ExecuteNonQuery();

        //        Connnection.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //}


        //#endregion

    }

    public static class LogDetails
    {

        public static String CurrentCompanyCode = "C01"; //Program.CurrentCompanyCode;
        public static int CurrentFinancialYear = 2016; //Program.CurrentFinancialYear;
        public static String CurrentDivID = "D01";     // Program.CurrentDivID;
        public static int UserId = 1; // Program.UserId;
        public static int DeletedTrue = 1;
        public static int DeletedFalse = 0;
        public static DateTime FromDate = DateTime.Now.Date;// Program.FromDate;
        public static DateTime ToDate = DateTime.Now.AddDays(90);// Program.ToDate;


    }

}
