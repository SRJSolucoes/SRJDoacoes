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

        public ISession GetCurrentSession()
        {
            ISession currentSession;
            var sessionFactory = SessionFactCRUD.GetSessionFact();
            currentSession = sessionFactory.OpenSession();


            return currentSession;
        }

        public static void DisposeCurrentSession()
        {
            var factoryCRUD = SessionFactCRUD.GetSessionFact();
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
