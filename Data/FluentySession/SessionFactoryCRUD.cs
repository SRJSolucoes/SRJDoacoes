using Data.Interfaces;
using NHibernate;
using NHibernate.Context;
using System;
using System.Diagnostics;

namespace Data.FluentySession
{
    public class SessionFactoryCRUD
    {

        public SessionFactoryCRUD()
        {
        }

        // TODO : TOAQUI
        public ISession GetCurrentSessionCRUD()
        {
            ISession currentSession;
            var sessionFactoryCRUD = SessionFact.GetSessionFactCRUD();

            currentSession = sessionFactoryCRUD.OpenSession();

            return currentSession;
        }

        public static void DisposeCurrentSession()
        {
            var factoryCRUD = SessionFact.GetSessionFactCRUD();
            var sessionCRUD = CurrentSessionContext.Unbind(factoryCRUD);
            if (sessionCRUD != null && sessionCRUD.IsOpen)
            {
                try
                {
                    if (sessionCRUD.Transaction != null && sessionCRUD.Transaction.IsActive)
                    {
                        sessionCRUD.Transaction.Rollback();
                        throw new Exception("Rolling back uncommited NHibernate transaction.");
                    }
                    sessionCRUD.Flush();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("SessionKey.EndContextSession", ex);
                    throw;
                }
                finally
                {
                    sessionCRUD.Close();
                    sessionCRUD.Dispose();
                }
            }
        }
    }
}
