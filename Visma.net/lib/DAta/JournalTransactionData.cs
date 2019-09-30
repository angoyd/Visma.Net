﻿using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class JournalTransactionData : BaseCrudDataClass<JournalTransaction>
    {
        public JournalTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.JournalTransaction;
        }

        public async Task AddAttachment(JournalTransaction journalTransaction, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, journalTransaction.GetIdentificator(), data, filename);
        }

        public async Task AddAttachment(JournalTransaction journalTransaction, int lineNumber, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, $"{journalTransaction.GetIdentificator()}/{lineNumber}", data, filename);
        }
    }
}