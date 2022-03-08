using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNoteWebApi.Models;
namespace StarNoteWebApi.DataAccess
{
    public interface IDAO
    {
      
        bool GenericAdd(object model,int savetype=0,int modeltype=0);
        bool GenericUpdate(object model, int modeltype = 0);
        bool GenericDelete(object model, int modeltype = 0);
       
        #region MainScreen
        int lastmainid();
        List<OrderModel> GetAll();
      
        List<string> GetSource(string method);
        List<JobOrderModel> getselectedjoborderlist(int id);
        StokModel Getselectedstok(string name);
        OrderModel Getselectedrecord(int id);
        
        List<string> joborderlist();
        string Createjoborder();
        #endregion

        #region analysis
        List<AnalysisMontlyModel> Fillmontlyanalysis(string datefilter,string type);
        List<AnalysisYearlyModel> Fillyearlyanalysis(string datefilter, string type);
        List<string> monthanalysissalesgaugefill(string datefilter, string type);
        List<string> monthanalysispurchasegaugefill(string datefilter, string type);
        List<string> monthanalysisnetgaugefill(string datefilter, string type);
        List<string> monthanalysispotansialgaugefill(string datefilter, string type);
        List<string> yearlyanalysissalesgaugefill(string datefilter, string type);
        List<string> yearlyanalysispurchasegaugefill(string datefilter, string type);
        List<string> yearlyanalysisnetgaugefill(string datefilter, string type);
        List<string> yearlyanalysispotansialgaugefill(string datefilter, string type);
        List<SalesmanAnalysisModel> Fillsalesmantablesales(string datefilter);
        List<SalesmanAnalysisModel> Fillsalesmantablepurchase(string datefilter);
        List<DataPoint> Loadsalespiessalesman(string datefilter);
        List<DataPoint> loadpurchasepiessalesman(string datefilter);
        #endregion

        #region company customer
        List<CompanyModel> GetAllCompany();      

        List<CostumerModel> GetAllCostumer();       
        #endregion

        #region accounting
        List<DataPoint> Loadsaleschartaccounting(string datefilter);
        List<DataPoint> loadpurchasechartsaccounting(string datefilter);
        List<DataPoint> Loadsalespiesaccounting(string datefilter);
        List<DataPoint> loadpurchasepiesaccounting(string datefilter);
        List<MontlyAccountingModel> Montlysalesfill(string datefilter);
        List<MontlyAccountingModel> Montlypurchasefill(string datefilter);
        List<DailyAccountingModel> dailysalesfill(string date);
        List<DailyAccountingModel> dailypurchasefill(string date);
        List<GaugeModel> dailysalesgaugefill(string date);
        List<GaugeModel> dailypurchasegaugefill(string date);
        #endregion
        #region filemanagement
        List<FilemanagementModel> GetFileListAll();
      
        List<FilemanagementModel> Getselectedfilelist(int id);
        #endregion

        #region lisance
        List<LisanceModel> GetAllLisance();
        bool Updatelisance(int Id, string status);
     
        #endregion

        #region product
        List<ParameterModel> GetAllProduct();
     
        #endregion

        #region reminding

        List<string> Filljoborderlist();
        List<RemindingModel> getoldremindingsforid(int id);
        List<RemindingModel> Getoldremidings();
      
        List<RemindingModel> GetselectedRemindingrecords(int Id);
        List<RemindingModel> GetAllRecords();
        List<string> Filltypesource();
        List<string> Fillstatussource();
        List<ParameterModel> GetTürAllreminding();
    
        #endregion

        #region salesman
        List<ParameterModel> GetSalesmanAll();     
        #endregion

        #region stok
        List<StokModel> GetStokAll();      
        List<string> BirimStokSourcelist();
        List<string> KdvStokSourcelist();
        
        #endregion

        #region type
        List<ParameterModel> GetTypeAll();
     
        #endregion

        #region typedetail
        List<ParameterModel> GetTürdetayAll();
       
        #endregion

        #region user
        List<UsersModel> Fillusermodel();
   
        bool Passwordchange(UsersModel password);
        #endregion
    }
}
