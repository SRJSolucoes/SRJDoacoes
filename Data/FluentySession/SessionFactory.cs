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

            //if (CurrentSessionContext.HasBind(sessionFactory))
            //{
            //    currentSession = sessionFactory.GetCurrentSession();
            //}
            //else
            //{
            //    currentSession = sessionFactory.OpenSession();
            //    CurrentSessionContext.Bind(currentSession);
            //}

            return currentSession;
        }

        public ISession GetCurrentSessionCRUD()
        {
            ISession currentSession;
            var sessionFactory = SessionFact.GetSessionFactCRUD();
            currentSession = sessionFactory.OpenSession();

            //if (CurrentSessionContext.HasBind(sessionFactory))
            //{
            //    currentSession = sessionFactory.GetCurrentSession();
            //}
            //else
            //{
            //    currentSession = sessionFactory.OpenSession();
            //    CurrentSessionContext.Bind(currentSession);
            //}

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
