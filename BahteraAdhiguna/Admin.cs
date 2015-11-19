using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace BahteraAdhiguna
{
    class Admin
    {
        Config con = new Config();
        private SqlConnection sqlcon;

        //ATTENDANCE MANAGEMENT//
        public ArrayList GetAttendanceTime()
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_att = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT AttendanceIn, AttendanceOut FROM Employees.Attendance where AttendanceStatus is null";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_att.Add(dr.GetDateTime(0));
                        data_att.Add(dr.GetDateTime(1));
                    } 
                }
                sqlcon.Close();
            }
            return data_att;
        }
        
        public int UpdateStatusAttendance(List<string> AttendanceStatus)
        {
            int i = 0;
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                const string sql = "UPDATE Employees.Attendance SET AttendanceStatus = @AttendanceStatus WHERE AttendanceStatus IS NULL";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@AttendanceStatus", AttendanceStatus));

                    sqlcom.ExecuteNonQuery();
                    i = 1;
                }
                sqlcon.Close();
            }
            return i;
        }

        //LOGIN AND PERSONALIZATION//

        public string[] Authentication(string UsersUname, string UsersPsswd)
        {
            sqlcon = con.ConnectSQL();
            string[] values = new string[3];
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT EmployeeNIP, EmployeePassword, EmployeeLevel FROM Employees.Employee WHERE EmployeeNIP = @UsersUname AND EmployeePassword = @UsersPsswd";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@UsersUname", UsersUname));
                    sqlcom.Parameters.Add(new SqlParameter("@UsersPsswd", UsersPsswd));

                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        values[0] = dr.GetString(0);
                        values[1] = dr.GetString(1);
                        values[2] = dr.GetString(2);
                    }
                    sqlcon.Close();
                }
            }
            return values;
        }

        public void UpdatePassword(string EmployeePassword, string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Employees.Employee SET EmployeePassword = @EmployeePassword WHERE EmployeeNIP = @EmployeeNIP";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeePassword", EmployeePassword));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeNIP", EmployeeNIP));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public void UserUpdatePhoto(string EmployeePhoto, string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Employees.Employee SET EmployeePhoto = @EmployeePhoto WHERE EmployeeNIP = @EmployeeNIP";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeePhoto", EmployeePhoto));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeNIP", EmployeeNIP));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public ArrayList UserBindEmpDetails(string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_emp = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT EmployeeNIP, EmployeeName, EmployeeGender, EmployeeDOB, EmployeeEmail, EmployeePhone, EmployeePhoto, DivisionID, PositionID FROM Employees.Employee WHERE EmployeeNIP = '" + EmployeeNIP + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_emp.Add(dr.GetString(0));
                        data_emp.Add(dr.GetString(1));
                        data_emp.Add(dr.GetString(2));
                        data_emp.Add(dr.GetDateTime(3).ToShortDateString());
                        data_emp.Add(dr.GetString(4));
                        data_emp.Add(dr.GetString(5));
                        data_emp.Add(dr.GetString(6));
                        data_emp.Add(dr.GetInt32(7).ToString());
                        data_emp.Add(dr.GetInt32(8).ToString());
                    }
                }
                sqlcon.Close();
            }
            return data_emp;
        }

        //EMPLOYEE MANAGEMENT//
        public void AddEmployee(string EmployeeNIP, string EmployeePassword, string EmployeeName, string EmployeeGender, string EmployeeDOB, string EmployeeEmail, string EmployeePhone, string EmployeePhoto, string DivisionID, string PositionID)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "INSERT INTO Employees.Employee VALUES(@EmployeeNIP, @EmployeePassword, @EmployeeLevel, @EmployeeName, @EmployeeGender, @EmployeeDOB, @EmployeeEmail, @EmployeePhone, @EmployeePhoto, @DivisionID, @PositionID)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeNIP", EmployeeNIP));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeePassword", EmployeePassword));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeLevel", "No"));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeName", EmployeeName));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeGender", EmployeeGender));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeDOB", EmployeeDOB));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeEmail", EmployeeEmail));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeePhone", EmployeePhone));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeePhoto", EmployeePhoto));
                    sqlcom.Parameters.Add(new SqlParameter("@DivisionID", DivisionID));
                    sqlcom.Parameters.Add(new SqlParameter("@PositionID", PositionID));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public void EditEmployee(string EmployeeNIP, string EmployeeName, string EmployeeGender, string EmployeeDOB, string EmployeeEmail, string EmployeePhone, string DivisionID, string PositionID)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Employees.Employee SET EmployeeName = @EmployeeName, EmployeeGender = @EmployeeGender, EmployeeDOB = @EmployeeDOB, EmployeeEmail = @EmployeeEmail, EmployeePhone = @EmployeePhone, DivisionID = @DivisionID, PositionID = @PositionID WHERE EmployeeNIP = @EmployeeNIP";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeNIP", EmployeeNIP));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeName", EmployeeName));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeGender", EmployeeGender));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeDOB", EmployeeDOB));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeEmail", EmployeeEmail));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeePhone", EmployeePhone));
                    sqlcom.Parameters.Add(new SqlParameter("@DivisionID", DivisionID));
                    sqlcom.Parameters.Add(new SqlParameter("@PositionID", PositionID));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public DataSet EmployeeDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT EmployeeNIP, EmployeeName, EmployeeGender, EmployeeDOB, EmployeeEmail, EmployeePhone FROM Employees.Employee";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "Employee");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public ArrayList BindEmpDetails(string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_emp = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT EmployeeNIP, EmployeeName, EmployeeGender, EmployeeDOB, EmployeeEmail, EmployeePhone, DivisionID, PositionID FROM Employees.Employee WHERE EmployeeNIP = '" + EmployeeNIP + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_emp.Add(dr.GetString(0));
                        data_emp.Add(dr.GetString(1));
                        data_emp.Add(dr.GetString(2));
                        data_emp.Add(dr.GetDateTime(3).ToShortDateString());
                        data_emp.Add(dr.GetString(4));
                        data_emp.Add(dr.GetString(5));
                        data_emp.Add(dr.GetInt32(6).ToString());
                        data_emp.Add(dr.GetInt32(7).ToString());
                    }
                }
                sqlcon.Close();
            }
            return data_emp;
        }

        //PAYROLL MANAGEMENT//
        public DataSet PayrollEmpDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT EmployeeNIP, EmployeeName, EmployeeEmail, EmployeePhone FROM Employees.Employee";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "Employee");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public ArrayList BindCBDivisionForEditAndSearchEmployeeForm(string DivisionID)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_division = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT DivisionID, DivisionName FROM Occupation.Division WHERE DivisionID='" + DivisionID + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_division.Add(dr.GetInt32(0).ToString());
                        data_division.Add(dr.GetString(1));
                    }
                }
                sqlcon.Close();
            }
            return data_division;
        }

        public ArrayList BindCBPositionForEditAndSearchEmployeeForm(string PositionID)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_position = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT PositionID, PositionName FROM Occupation.Position WHERE PositionID='" + PositionID + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_position.Add(dr.GetInt32(0).ToString());
                        data_position.Add(dr.GetString(1));
                    }
                }
                sqlcon.Close();
            }
            return data_position;
        }

        public void AddDivision(string DivisionName, string DivisionDescription)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "INSERT INTO Occupation.Division VALUES(@DivisionName,@DivisionDescription)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@DivisionName", DivisionName));
                    sqlcom.Parameters.Add(new SqlParameter("@DivisionDescription", DivisionDescription));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public void AddPosition(string PositionName, string PositionPayrollBase, string DivisionID)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "INSERT INTO Occupation.Position VALUES(@PositionName, @PositionPayrollBase, @DivisionID)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@PositionName", PositionName));
                    sqlcom.Parameters.Add(new SqlParameter("@PositionPayrollBase", PositionPayrollBase));
                    sqlcom.Parameters.Add(new SqlParameter("@DivisionID", DivisionID));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public ArrayList BindCBDivision()
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_division = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT DivisionID, DivisionName FROM Occupation.Division", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_division.Add(dr.GetInt32(0).ToString());
                        data_division.Add(dr.GetString(1));
                    }
                }
                sqlcon.Close();
            }
            return data_division;
        }

        public ArrayList BindCBPosition(string DivisionID)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_division = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT PositionID, PositionName FROM Occupation.Position WHERE DivisionID ='" + DivisionID + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_division.Add(dr.GetInt32(0).ToString());
                        data_division.Add(dr.GetString(1));
                    }
                }
                sqlcon.Close();
            }
            return data_division;
        }

        public DataSet DivisionDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT * FROM Occupation.Division";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "Division");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public DataSet PositionDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT * FROM Occupation.Position";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "Position");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public ArrayList BindPayrollDetails(string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_payroll = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT EmployeeNIP, PayrollBase, PayrollTotal, PayrollPositionAllowanceTotal, PayrollTransportationAllowanceTotal, PayrollHouseAllowanceTotal, PayrollAnotherAllowanceTotal, PayrollReductionTotal FROM Employees.Payroll WHERE EmployeeNIP = '" + EmployeeNIP + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_payroll.Add(dr.GetString(0));
                        data_payroll.Add(dr.GetInt32(1).ToString());
                        data_payroll.Add(dr.GetInt32(2).ToString());
                        data_payroll.Add(dr.GetInt32(3).ToString());
                        data_payroll.Add(dr.GetInt32(4).ToString());
                        data_payroll.Add(dr.GetInt32(5).ToString());
                        data_payroll.Add(dr.GetInt32(6).ToString());
                        data_payroll.Add(dr.GetInt32(7).ToString());
                    }
                }
                sqlcon.Close();
            }
            return data_payroll;
        }

        public ArrayList BindAddPayrollDetails(string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_payroll = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT EmployeeNIP, PositionPayrollBase FROM Employees.Employee E JOIN Occupation.Position P on  E.PositionID = P.PositionID WHERE EmployeeNIP = '" + EmployeeNIP + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_payroll.Add(dr.GetString(0));
                        data_payroll.Add(dr.GetDecimal(1).ToString());
                    }
                }
                sqlcon.Close();
            }
            return data_payroll;
        }

        //CONTRACT MANAGEMENT//

        public ArrayList CheckContractExpiration()
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_contract = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT ContractNumber, ContractEndDate FROM Occupation.Contracts WHERE ContractStatus ='ONGOING'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_contract.Add(dr.GetString(0));
                        data_contract.Add(dr.GetDateTime(1).ToShortDateString());
                    }
                }
                sqlcon.Close();
            }
            return data_contract;
        }


        public void AddContract(string ContractNumber, string ContractName, string ContractDescription, string ContractTimePeriod, string ContractStartDate, string ContractEndDate, string ContractInfo, string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "INSERT INTO Occupation.Contracts VALUES(@ContractNumber, @ContractName, @ContractDescription, @ContractTimePeriod, @ContractStartDate, @ContractEndDate, @ContractStatus, @ContractInfo, @EmployeeNIP)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@ContractNumber", ContractNumber));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractName", ContractName));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractDescription", ContractDescription));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractTimePeriod", ContractTimePeriod));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractStartDate", ContractStartDate));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractEndDate", ContractEndDate));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractStatus", "ONGOING"));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractInfo", ContractInfo));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeNIP", EmployeeNIP));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public DataSet ContractDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT ContractNumber, ContractName, ContractStartDate, ContractEndDate FROM Occupation.Contracts";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "Contracts");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public DataSet GetOngoingContractDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT ContractNumber, ContractName, ContractStartDate, ContractEndDate, ContractStatus FROM Occupation.Contracts WHERE ContractStatus ='ONGOING'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "OngoingContracts");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public DataSet GetCompletedContractDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT ContractNumber, ContractName, ContractStartDate, ContractEndDate, ContractStatus FROM Occupation.Contracts WHERE ContractStatus ='COMPLETED'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "CompletedContracts");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public DataSet GetExtendedContractDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT ContractNumber, ContractName, ContractStartDate, ContractEndDate, ContractStatus FROM Occupation.Contracts WHERE ContractStatus ='EXTENDED'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "ExtendedContracts");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public ArrayList BindOngoingContract(string ContractNumber)
        {
            sqlcon = con.ConnectSQL(); 
            ArrayList data_contract = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT ContractNumber, ContractName, ContractTimePeriod, ContractEndDate, ContractStatus FROM Occupation.Contracts WHERE ContractNumber = '" + ContractNumber + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_contract.Add(dr.GetString(0));
                        data_contract.Add(dr.GetString(1));
                        data_contract.Add(dr.GetString(2));
                        data_contract.Add(dr.GetDateTime(3).ToShortDateString());
                        data_contract.Add(dr.GetString(4));
                    }
                }
                sqlcon.Close();
            }
            return data_contract;
        }

        public void UpdateContractStatus(string ContractNumber)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Occupation.Contracts SET ContractStatus = 'COMPLETED' WHERE ContractNumber = @ContractNumber";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@ContractNumber", ContractNumber));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public ArrayList BindAllContractDetails(string ContractNumber)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_contract = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT ContractNumber, ContractName, ContractDescription, ContractTimePeriod, ContractStartDate, ContractEndDate, ContractStatus, ContractInfo FROM Occupation.Contracts WHERE ContractNumber = '" + ContractNumber + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_contract.Add(dr.GetString(0));
                        data_contract.Add(dr.GetString(1));
                        data_contract.Add(dr.GetString(2));
                        data_contract.Add(dr.GetString(3));
                        data_contract.Add(dr.GetDateTime(4));
                        data_contract.Add(dr.GetDateTime(5));
                        data_contract.Add(dr.GetString(6));
                        data_contract.Add(dr.GetString(7));
                    }
                }
                sqlcon.Close();
            }
            return data_contract;
        }

        public DataSet GetSearchContractDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT ContractNumber, ContractName, ContractStatus FROM Occupation.Contracts";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "SearchContracts");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public DataSet GetEditContractDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT * FROM Occupation.Contracts WHERE ContractStatus ='ONGOING'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "EditContracts");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public void EditContractDetails(string ContractNumber, string ContractName, string ContractDescription, string ContractTimePeriod, string ContractStartDate, string ContractEndDate, string ContractInfo)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Occupation.Contracts SET ContractName = @ContractName, ContractDescription = @ContractDescription, ContractTimePeriod = @ContractTimePeriod, ContractStartDate = @ContractStartDate, ContractEndDate = @ContractEndDate, ContractStatus = @ContractStatus, ContractInfo = @ContractInfo WHERE ContractNumber = '" + ContractNumber + "'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@ContractName", ContractName));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractDescription", ContractDescription));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractTimePeriod", ContractTimePeriod));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractStartDate", ContractStartDate));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractEndDate", ContractEndDate));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractStatus", "EXTENDED"));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractInfo", ContractInfo));
                    sqlcom.Parameters.Add(new SqlParameter("@ContractNumber", ContractNumber));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        //INVENTORY MANAGEMENT//

        public string InventoryAutoGenerateID()
        {
            sqlcon = con.ConnectSQL();
            string id = null;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT TOP 1 InventoryNumber FROM Operational.Inventories ORDER BY InventoryNumber DESC";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr.GetString(0);
                        string sub = id.Substring(2);
                        int a = Convert.ToInt32(sub) + 1;
                        if (a < 10)
                        {
                            id = "IN0000000" + a;
                        }
                        else if (a < 100)
                        {
                            id = "IN000000" + a;
                        }
                        else if (a < 1000)
                        {
                            id = "IN00000" + a;
                        }
                        else if (a < 10000)
                        {
                            id = "IN0000" + a;
                        }
                        else if (a < 100000)
                        {
                            id = "IN000" + a;
                        }
                        else if (a < 1000000)
                        {
                            id = "IN00" + a;
                        }
                        else if (a < 10000000)
                        {
                            id = "IN0" + a;
                        }
                        else if (a < 100000000)
                        {
                            id = "IN" + a;
                        }
                    }
                    else
                    {
                        id = "IN00000001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public void AddInventory(string InventoryNumber, string InventoryName, string InventoryDescription, string InventoryCategory, string InventoryStock)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "INSERT INTO Operational.Inventories VALUES(@InventoryNumber, @InventoryName, @InventoryDescription, @InventoryCategory, @InventoryStock)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryNumber", InventoryNumber));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryName", InventoryName));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryDescription", InventoryDescription));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryCategory", InventoryCategory));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryStock", InventoryStock));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public DataSet InventoryDGV()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT * FROM Operational.Inventories";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "Inventory");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public ArrayList BindAllItemDetails(string ItemNumber)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_invent = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT * FROM Operational.Inventories WHERE InventoryNumber = '" + ItemNumber + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_invent.Add(dr.GetString(0));
                        data_invent.Add(dr.GetString(1));
                        data_invent.Add(dr.GetString(2));
                        data_invent.Add(dr.GetString(3));
                        data_invent.Add(dr.GetInt64(4));
                    }
                }
                sqlcon.Close();
            }
            return data_invent;
        }

        public void UpdateStock(string InventoryNumber, string InventoryName, string InventoryDescription, string InventoryCategory, string InventoryStock)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Operational.Inventories SET InventoryName = @InventoryName, InventoryDescription = @InventoryDescription, InventoryCategory = @InventoryCategory, InventoryStock = @InventoryStock  WHERE InventoryNumber = @InventoryNumber";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryName", InventoryName));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryDescription", InventoryDescription));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryCategory", InventoryCategory));
                    sqlcom.Parameters.Add(new SqlParameter("@InventoryStock", InventoryStock));

                    sqlcom.Parameters.Add(new SqlParameter("@InventoryNumber", InventoryNumber));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        //PETTY CASH MANAGEMENT//
        public string PettyCashAutoGenerateID()
        {
            sqlcon = con.ConnectSQL();
            string id = null;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT TOP 1 PettyCashNumber FROM Operational.PettyCash ORDER BY PettyCashNumber DESC";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr.GetString(0);
                        string sub = id.Substring(2);
                        int a = Convert.ToInt32(sub) + 1;
                        if (a < 10)
                        {
                            id = "PC0000000" + a;
                        }
                        else if (a < 100)
                        {
                            id = "PC000000" + a;
                        }
                        else if (a < 1000)
                        {
                            id = "PC00000" + a;
                        }
                        else if (a < 10000)
                        {
                            id = "PC0000" + a;
                        }
                        else if (a < 100000)
                        {
                            id = "PC000" + a;
                        }
                        else if (a < 1000000)
                        {
                            id = "PC00" + a;
                        }
                        else if (a < 10000000)
                        {
                            id = "PC0" + a;
                        }
                        else if (a < 100000000)
                        {
                            id = "PC" + a;
                        }
                    }
                    else
                    {
                        id = "PC00000001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }
         
        public DataSet PettyCashDGVLend()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT PettyCashNumber, PettyCashDescription, PettyCashValue FROM Operational.PettyCash WHERE PettyCashStatus = 'LEND'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "PettyCash");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public DataSet PettyCashDGVReturn()
        {
            sqlcon = con.ConnectSQL();
            DataSet dse = new DataSet();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "SELECT PettyCashNumber, PettyCashDescription, PettyCashValue FROM Operational.PettyCash WHERE PettyCashStatus = 'RETURNED'";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;
                    sda.Fill(dse, "PettyCash");
                }
                sqlcon.Close();
            }
            return dse;
        }

        public void AddPettyCash(string PettyCashNumber, string PettyCashDescription, string PettyCashTakeDate, string PettyCashValue, string EmployeeNIP)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "INSERT INTO Operational.PettyCash VALUES(@PettyCashNumber, @PettyCashDescription, @PettyCashTakeDate, @PettyCashBackDate, @PettyCashValue, @PettyCashStatus, @EmployeeNIP)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashNumber", PettyCashNumber));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashDescription", PettyCashDescription));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashTakeDate", PettyCashTakeDate));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashBackDate", PettyCashTakeDate));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashValue", PettyCashValue));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashStatus", "LEND"));
                    sqlcom.Parameters.Add(new SqlParameter("@EmployeeNIP", EmployeeNIP));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }

        public ArrayList BindPettyCashDetails(string PettyCashNumber)
        {
            sqlcon = con.ConnectSQL();
            ArrayList data_cash = new ArrayList();
            using (sqlcon)
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("SELECT PettyCashNumber, PettyCashDescription, PettyCashTakeDate, PettyCashValue FROM Operational.PettyCash WHERE PettyCashNumber = '" + PettyCashNumber + "'", sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        data_cash.Add(dr.GetString(0));
                        data_cash.Add(dr.GetString(1));
                        data_cash.Add(dr.GetDateTime(2).ToShortDateString());
                        data_cash.Add(dr.GetDecimal(3).ToString());
                    }
                    sqlcon.Close();
                }
                return data_cash;
            }
        }

        public void UpdatePettyCashStatus(string PettyCashNumber, string PettyCashBackDate)
        {
            sqlcon = con.ConnectSQL();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "UPDATE Operational.PettyCash SET PettyCashBackDate = @PettyCashBackDate, PettyCashStatus = @PettyCashStatus WHERE PettyCashNumber = @PettyCashNumber";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashBackDate", PettyCashBackDate));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashStatus", "RETURNED"));
                    sqlcom.Parameters.Add(new SqlParameter("@PettyCashNumber", PettyCashNumber));

                    sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
        }
    }
}
