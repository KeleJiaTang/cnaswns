using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace Cnas.wns.CnasBaseInterface
{
    public interface CnasHCSInterface
    {
         string CheckSelectData(string ConSN, SortedList inpar);
         DataTable SelectData(string ConSN, SortedList inpar);
         string CheckUPData(int uptype, string ConSN, SortedList inpar01, SortedList inpar02);
         int UPData(int uptype, string ConSN, SortedList inpar01, SortedList inpar02);
         string Get_SerialNumber(int intype);

		 string CheckUPDataList(string conSN, SortedList parameters);
		 int UPDataList(string conSN, SortedList parameters);
		 DataSet ExecuteProcedure(string procedureName, SortedList parameters);
		 int GetSerialNumber(int number, string type);
         SortedList GetSystemData(int intype,SortedList indata);
    }


    public interface CnasHCSWorkflowInterface
    {
        SortedList GetWorkflowParametersValue(int intype, int subtype, SortedList par01, SortedList par02, SortedList par03);
        SortedList SubmitNextWorkflow(int intype, SortedList par01, SortedList par02, SortedList par03);
        SortedList SubmitProcedureManual(int intype, SortedList par01, SortedList par02, SortedList par03);
        SortedList ifinwf(string inbcdata, string inpddata, DataTable inbasedata);
        SortedList Get_BarCode_PrintData(string in_barcode, SortedList sl_par01, SortedList sl_par02);
		SortedList CheckBusinessLogic(string barCode, Dictionary<string, string> scanCodes);
        string GetVersions();
		void UpUrgent(bool isDone);
    }
}
