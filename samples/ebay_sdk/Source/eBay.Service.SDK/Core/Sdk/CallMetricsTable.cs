#region Copyright
//	Copyright (c) 2007 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion

#region Namespaces
#endregion

using System.Collections;
using eBay.Service.Util;

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// 
	/// </summary>
	public class CallMetricsTable
	{

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CallMetricsTable() 
		{
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="metrics"></param>
		#region Public Methods
		public void AddCallMetrics(CallMetricsEntry metrics)
		{
			lock(this)
			{
				string callname = metrics.CallName;
				ArrayList metricsList = (ArrayList) mMetricsTable[callname];
				if (metricsList == null)
				{
					metricsList = new ArrayList();
					mMetricsTable[callname] = metricsList;
				}
				metricsList.Add(metrics);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="callname"></param>
		/// <returns></returns>
		public CallMetricsEntry GetNewEntry(string callname)
		{
			CallMetricsEntry metrics = new CallMetricsEntry(callname);
			AddCallMetrics(metrics);
			return metrics;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		public void Log(string str)
		{
			mLogger.RecordMessage(str, MessageSeverity.Informational);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="metricsList"></param>
		/// <returns></returns>
		private long[] GenerateAverage(ArrayList metricsList)
		{
			long [] averages = new long[NUMBER_OF_COLUMNS];
		
			for (int i=0; i<averages.Length; i++)
			{
				averages[i] = 0;
			}
			for (int i = 0; i < metricsList.Count; i++)
			{
				CallMetricsEntry metrics = (CallMetricsEntry) metricsList[i];
				metrics.UpdateTotals(averages);
			}
			for (int i=0; i<averages.Length; i++)
			{
				averages[i] /= metricsList.Count;
			}
			return averages;
		}

		/// <summary>
		/// 
		/// </summary>
        /// <param name="callname"></param>
		/// <param name="logger"></param>
		/// <param name="metricsList"></param>
		private void GenerateReportPerCallname(string callname, ApiLogger logger, ArrayList metricsList)
		{
			mLogger = logger;
            Log("Call name: " + callname);
			Log("Number of calls recorded: " + metricsList.Count);
			Log("Total     Setup     Network   Server    Finish    Start Time          ");
			Log("======================================================================");
			for (int i = 0; i < metricsList.Count; i++)
			{
				CallMetricsEntry metrics = (CallMetricsEntry) metricsList[i];
				metrics.GenerateReport(logger);
			}
			string avgstring = "";
			if (metricsList.Count > 0)
			{
				long[] averages = GenerateAverage(metricsList);
				for (int i = 0; i<averages.Length; i++)
				{
					avgstring += CallMetricsEntry.FormatNumber(averages[i]);
				}
			}
            Log("Average : ");
            Log(avgstring);
            Log("======================================================================");
		}

        /// <summary>
        /// 
        /// </summary>
        public void GenerateReport(ApiLogger logger)
		{
			ICollection keyCollection = mMetricsTable.Keys;
			foreach (string callname in keyCollection)
			{
				ArrayList metricsList = (ArrayList) mMetricsTable[callname];
				GenerateReportPerCallname(callname, logger, metricsList);
			}

	}

		#endregion

		#region Private Fields
		private int NUMBER_OF_COLUMNS = 5;
		private ApiLogger mLogger = null;
		private Hashtable mMetricsTable = new Hashtable();
		#endregion
	}

}
