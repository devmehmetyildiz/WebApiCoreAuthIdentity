using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarNoteWebApi.Models;

namespace StarNoteWebApi.DataAccess
{
    public class DAOFactory : IDAO
    {
        AccountingDAO accountingDAO;
        AnalysisDAO analysisDAO;
        CompanyDAO companyDAO;
        CostumerDAO costumerDAO;
        FilemanagementDAO filemanagementDAO;
        LisanceDAO lisanceDAO;
        MainDAO mainDAO;
        ProductDAO productDAO;
        RemindingDAO remindingDAO;
        SalesmanDAO salesmanDAO;
        StokDAO stokDAO;
        TypeDAO typeDAO;
        TypeDetailDAO typedetailDAO;
        UserDAO userDAO;

        public DAOFactory()
        {
            accountingDAO = new AccountingDAO();
            analysisDAO = new AnalysisDAO();
            companyDAO = new CompanyDAO();
            costumerDAO = new CostumerDAO();
            filemanagementDAO = new FilemanagementDAO();
            lisanceDAO = new LisanceDAO();
            mainDAO = new MainDAO();
            productDAO = new ProductDAO();
            remindingDAO = new RemindingDAO();
            salesmanDAO = new SalesmanDAO();
            stokDAO = new StokDAO();
            typeDAO = new TypeDAO();
            typedetailDAO = new TypeDetailDAO();
            userDAO = new UserDAO();
        }

        public bool GenericAdd(object Model, int savetype = 0, int modeltype = 0)
        {
            bool isok = false;
            switch (Model)
            {
                case OrderModel model:
                    isok = mainDAO.AddMain(model, modeltype);
                    break;
                case CompanyModel model:
                    isok = companyDAO.Add(model);
                    break;
                case CostumerModel model:
                    isok = costumerDAO.Add(model);
                    break;
                case FilemanagementModel model:
                    isok = filemanagementDAO.AddFile(model);
                    break;
                case LisanceModel model:
                    isok = lisanceDAO.Addlisance(model);
                    break;             
                case RemindingModel model:
                    isok = remindingDAO.Add(model);
                    break;
                case StokModel model:
                    isok = stokDAO.AddStok(model);
                    break;
                case UsersModel model:
                    isok = userDAO.AddUser(model);
                    break;
                case ParameterModel model:
                    if (modeltype == BaseDAO.Salesman)
                        isok = salesmanDAO.Add(model);
                    if (modeltype == BaseDAO.Type)
                        isok = typeDAO.AddTür(model);
                    if (modeltype == BaseDAO.TypeDetail)
                        isok = typedetailDAO.AddTür(model);
                    if (modeltype == BaseDAO.Product)
                        isok = productDAO.Add(model);                   
                    break;
            }
            return isok;
        }
        public bool GenericDelete(object Model, int modeltype = 0)
        {
            bool isok = false;
            switch (Model)
            {
                case CompanyModel model:
                    isok = companyDAO.Delete(model);
                    break;
                case CostumerModel model:
                    isok = costumerDAO.Delete(model);
                    break;
                case FilemanagementModel model:
                    isok = filemanagementDAO.DeleteFile(model);
                    break;              
                case UsersModel model:
                    isok = userDAO.DeleteUser(model);
                    break;
                case ParameterModel model:
                    if (modeltype == BaseDAO.Salesman)
                        isok = salesmanDAO.Delete(model);
                    if (modeltype == BaseDAO.Type)
                        isok = typeDAO.DeleteTür(model);
                    if (modeltype == BaseDAO.TypeDetail)
                        isok = typedetailDAO.DeleteTür(model);
                    if (modeltype == BaseDAO.Product)
                        isok = productDAO.Delete(model);
                    break;
            }
            return isok;
        }
        public bool GenericUpdate(object Model, int modeltype = 0)
        {
            bool isok = false;
            switch (Model)
            {
                case OrderModel model:
                    isok = mainDAO.UpdateMain(model);
                    break;
                case CompanyModel model:
                    isok = companyDAO.Update(model);
                    break;
                case CostumerModel model:
                    isok = costumerDAO.Update(model);
                    break;
                case FilemanagementModel model:
                    isok = filemanagementDAO.AddFile(model);
                    break;              
                case RemindingModel model:
                    isok = remindingDAO.Update(model);
                    break;
                case StokModel model:
                    isok = stokDAO.UpdateStok(model);
                    break;
                case UsersModel model:
                    isok = userDAO.UpdateUser(model);
                    break;
                case ParameterModel model:
                    if (modeltype == BaseDAO.Salesman)
                        isok = salesmanDAO.Update(model);
                    if (modeltype == BaseDAO.Type)
                        isok = typeDAO.UpdateTür(model);
                    if (modeltype == BaseDAO.TypeDetail)
                        isok = typedetailDAO.UpdateTür(model);
                    if (modeltype == BaseDAO.Product)
                        isok = productDAO.Update(model);
                    break;
            }
            return isok;
        }

        #region maindao
        public List<string> joborderlist()
        {
            return mainDAO.joborderlist();
        }
        public OrderModel Getselectedrecord(int id)
        {
            return mainDAO.Getselectedrecord(id);
        }
        public List<JobOrderModel> getselectedjoborderlist(int Id)
        {
            return mainDAO.GetSelectedJoborders(Id);
        }


        public string Createjoborder()
        {
            return mainDAO.Createjoborder();
        }
        public StokModel Getselectedstok(string name)
        {
            return stokDAO.Getselectedstok(name);
        }
        public List<string> GetSource(string method)
        {
            return mainDAO.GetSource(method);
        }
        public List<OrderModel> GetAll()
        {
            return mainDAO.GetAll();
        }
        public int lastmainid()
        {
            return mainDAO.lastmainid();
        }
        #endregion

        #region stokdao
        public List<string> BirimStokSourcelist()
        {
            return stokDAO.BirimStokSourcelist();
        }
        public List<string> KdvStokSourcelist()
        {
            return stokDAO.KdvStokSourcelist();
        }
        public List<StokModel> GetStokAll()
        {
            return stokDAO.GetStokAll();
        }

       
        #endregion

        public List<UsersModel> Fillusermodel()
        {
            return userDAO.Fillusermodel();
        }
        public bool Passwordchange(UsersModel password)
        {
            return userDAO.Passwordchange(password);
        }
        public List<CompanyModel> GetAllCompany()
        {
            return companyDAO.Filllist();
        }
        public List<CostumerModel> GetAllCostumer()
        {
            return costumerDAO.Filllist();
        }
        public List<ParameterModel> GetSalesmanAll()
        {
            return salesmanDAO.GetSalesmanAll();
        }
        public List<LisanceModel> GetAllLisance()
        {
            return lisanceDAO.GetAll();
        }
        public bool Updatelisance(int Id, string status)
        {
            return lisanceDAO.Updatelisance(Id, status);
        }
        public List<ParameterModel> GetAllProduct()
        {
            return productDAO.GetAll();
        }
        public List<FilemanagementModel> GetFileListAll()
        {
            return filemanagementDAO.GetFileListAll();
        }
        public List<FilemanagementModel> Getselectedfilelist(int id)
        {
            return filemanagementDAO.Getselectedfilelist(id);
        }      
        public List<ParameterModel> GetTypeAll()
        {
            return typeDAO.GetTürAll();
        }        
        public List<ParameterModel> GetTürdetayAll()
        {
            return typedetailDAO.GetTürAll();
        }       
      
        #region
        public List<RemindingModel> GetselectedRemindingrecords(int Id)
        {
            return remindingDAO.GetselectedRemindingrecords(Id);
        }
        public List<ParameterModel> GetTürAllreminding()
        {
            return typeDAO.GetTürAll();
        }
        public List<RemindingModel> GetAllRecords()
        {
            return remindingDAO.GetAllRecords();
        }
        public List<string> Filljoborderlist()
        {
            return remindingDAO.Filljoborderlist();
        }
        public List<string> Fillstatussource()
        {
            return remindingDAO.Fillstatussource();
        }

        public List<string> Filltypesource()
        {
            return remindingDAO.Filltypesource();
        }
        public List<RemindingModel> Getoldremidings()
        {
            return remindingDAO.Getoldremidings();
        }
        public List<RemindingModel> getoldremindingsforid(int id)
        {
            return remindingDAO.getoldremindingsforid(id);
        }
#endregion

        #region accountingdao
        public List<DataPoint> loadpurchasechartsaccounting(string datefilter)
        {
            return accountingDAO.loadpurchasecharts(datefilter);
        }
        public List<DataPoint> loadpurchasepiesaccounting(string datefilter)
        {
            return accountingDAO.loadpurchasepies(datefilter);
        }
        public List<DataPoint> Loadsaleschartaccounting(string datefilter)
        {
            return accountingDAO.Loadsaleschart(datefilter);
        }
        public List<DataPoint> Loadsalespiesaccounting(string datefilter)
        {
            return accountingDAO.Loadsalespies(datefilter);
        }

        public List<MontlyAccountingModel> Montlypurchasefill(string datefilter)
        {
            return accountingDAO.Montlypurchasefill(datefilter);
        }
        public List<DailyAccountingModel> dailypurchasefill(string date)
        {
            return accountingDAO.dailypurchasefill(date);
        }

        public List<GaugeModel> dailypurchasegaugefill(string date)
        {
            return accountingDAO.dailypurchasegaugefill(date);
        }
        public List<DailyAccountingModel> dailysalesfill(string date)
        {
            return accountingDAO.dailysalesfill(date);
        }

        public List<GaugeModel> dailysalesgaugefill(string date)
        {
            return accountingDAO.dailysalesgaugefill(date);
        }
        public List<MontlyAccountingModel> Montlysalesfill(string datefilter)
        {
            return accountingDAO.Montlysalesfill(datefilter);
        }
        #endregion

        #region analysisdao
        public List<DataPoint> loadpurchasepiessalesman(string datefilter)
        {
            return analysisDAO.loadpurchasepiessalesman(datefilter);
        }

        public List<string> yearlyanalysisnetgaugefill(string datefilter, string type)
        {
            return analysisDAO.yearlyanalysisnetgaugefill(datefilter, type);
        }

        public List<string> yearlyanalysispurchasegaugefill(string datefilter, string type)
        {
            return analysisDAO.yearlyanalysispurchasegaugefill(datefilter, type);
        }

        public List<string> yearlyanalysissalesgaugefill(string datefilter, string type)
        {
            return analysisDAO.yearlyanalysissalesgaugefill(datefilter, type);
        }

        public List<DataPoint> Loadsalespiessalesman(string datefilter)
        {
            return analysisDAO.Loadsalespiessalesman(datefilter);
        }
        public List<string> monthanalysisnetgaugefill(string datefilter, string type)
        {
            return analysisDAO.monthanalysisnetgaugefill(datefilter, type);
        }

        public List<string> monthanalysispurchasegaugefill(string datefilter, string type)
        {
            return analysisDAO.monthanalysispurchasegaugefill(datefilter, type);
        }

        public List<string> monthanalysissalesgaugefill(string datefilter, string type)
        {
            return analysisDAO.monthanalysissalesgaugefill(datefilter, type);
        }

        public List<AnalysisYearlyModel> Fillyearlyanalysis(string datefilter, string type)
        {
            return analysisDAO.Fillyearlyanalysis(datefilter,type);
        }

        public List<AnalysisMontlyModel> Fillmontlyanalysis(string datefilter,string type)
        {
            return analysisDAO.Fillmontlyanalysis(datefilter,type);
        }

        public List<SalesmanAnalysisModel> Fillsalesmantablepurchase(string datefilter)
        {
            return analysisDAO.Fillsalesmantablepurchase(datefilter);
        }

        public List<SalesmanAnalysisModel> Fillsalesmantablesales(string datefilter)
        {
            return analysisDAO.Fillsalesmantablesales(datefilter);
        }

        public List<string> monthanalysispotansialgaugefill(string datefilter, string type)
        {
            return analysisDAO.monthanalysispotansialgaugefill(datefilter, type);
        }

        public List<string> yearlyanalysispotansialgaugefill(string datefilter, string type)
        {
            return analysisDAO.yearlyanalysispotansialgaugefill(datefilter, type);
        }


        #endregion
    }
}