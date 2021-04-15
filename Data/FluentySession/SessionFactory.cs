using Data.Interfaces;
using NHibernate;
using NHibernate.Context;
using System;
using System.Diagnostics;

namespace Data.FluentySession
{
    public class SessionFactory
    {

        public SessionFactory()
        {
        }

        public ISession GetCurrentSession()
        {
            ISession currentSession;
            var sessionFactory = SessionFact.GetSessionFact();
            currentSession = sessionFactory.OpenSession();

            return currentSession;
        }

        public static void DisposeCurrentSession()
        {
            var factory = SessionFact.GetSessionFact();
            var session = CurrentSessionContext.Unbind(factory);
            if (session != null && session.IsOpen)
            {
                try
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        session.Transaction.Rollback();
                        throw new Exception("Rolling back uncommited NHibernate transaction.");
                    }
                    session.Flush();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("SessionKey.EndContextSession", ex);
                    throw;
                }
                finally
                {
                    session.Close();
                    session.Dispose();
                }
            }
        }
    }
}
