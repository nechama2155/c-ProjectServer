using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class Cast
    {
        #region assessorTodal
        public static Assessor assessorTodal(BLAssessor bla)
        {
            Assessor a = new Assessor()
            {
                AssessorId = bla.AssessorId,
                AssessorFirstName = bla.AssessorFirstName,
                AssessorLastName = bla.AssessorLastName,
                AssessorCity = bla.AssessorCity,
                AssessorAddress = bla.AssessorAddress,
                AssessorPhone = bla.AssessorPhone,
                AssessorEmail = bla.AssessorEmail,
                Seniority = bla.Seniority,
                Available = bla.Available,
                IsManager = bla.IsManager,
                NumOfCustomers = bla.NumOfCustomers,
            };
            return a;
        }


        #endregion

        #region assessorTobl

        public static BLAssessor assessorTobl(Assessor a)
        {
            BLAssessor bla = new BLAssessor()
            {
                AssessorId = a.AssessorId,
                AssessorFirstName = a.AssessorFirstName,
                AssessorLastName = a.AssessorLastName,
                AssessorCity = a.AssessorCity,
                AssessorAddress = a.AssessorAddress,
                AssessorPhone = a.AssessorPhone,
                AssessorEmail = a.AssessorEmail,
                Seniority = a.Seniority,
                Available = a.Available,
                IsManager = a.IsManager,
                NumOfCustomers = (int)a.NumOfCustomers,
            };
            return bla;
        }
#endregion

        #region applicationTodal
        public static Application applicationTodal(BLApplications blapp)
        {
            Application a = new Application()
            {
                ApplicationId = blapp.ApplicationId,
                AssessorId = blapp.AssessorId,
                ApplicationDate = blapp.ApplicationDate,
                LastApplicationDate = blapp.LastApplicationDate,
                ApplicationStatus = blapp.ApplicationStatus,
            };

            return a;
        }
        #endregion

        #region applicationTobl
        public static BLApplications applicationTobl(Application a)
        {

            BLApplications blapp = new BLApplications()
            {
                ApplicationId = a.ApplicationId,
                AssessorId = a.AssessorId,
                ApplicationDate = a.ApplicationDate,
                LastApplicationDate = a.LastApplicationDate,
                ApplicationStatus = a.ApplicationStatus,
            };
            return blapp;
        }
        #endregion

        #region assessmentTodal
        public static Assessment assessmentTodal(BLAssessment bla)
        {
            Assessment a = new Assessment()
            {
                AssessmentId = bla.AssessmentId,
                Block = bla.Block,
                Plot = bla.Plot,
                SubPlot = bla.SubPlot,
                ConstructionYear = bla.ConstructionYear,
                AcquisionPrice = bla.AcquisionPrice,
                AssessmentGoal = bla.AssessmentGoal,
                LegalState = bla.LegalState,
                BuildingPermit = bla.BuildingPermit,
                IrregularitiesBuilding = bla.IrregularitiesBuilding
            };
            return a;
        }
        #endregion

        #region assessmentTobl
        public static BLAssessment assessmentTobl(Assessment a)
        {
            BLAssessment bla = new BLAssessment()
            {
                AssessmentId = a.AssessmentId,
                Block = a.Block != null ? a.Block : "",
                Plot = a.Plot != null ? a.Plot : "",
                SubPlot = a.SubPlot != null ? a.SubPlot : "",
                ConstructionYear = a.ConstructionYear != null ? a.ConstructionYear : "",
                AcquisionPrice = (int)(a.AcquisionPrice != null ? a.AcquisionPrice : 0),
                AssessmentGoal = a.AssessmentGoal != null ? a.AssessmentGoal : "",
                LegalState = a.LegalState != null ? a.LegalState : "",
                BuildingPermit = a.BuildingPermit != null ? a.BuildingPermit : "",
                IrregularitiesBuilding = a.IrregularitiesBuilding != null ? a.IrregularitiesBuilding : "",
            };
            return bla;
        }
        #endregion

        #region customerTodal
        public static Customer customerTodal(BLCustomer blc)
        {
            Customer c = new Customer()
            {
                CustomerId = blc.CustomerId,
                CustomerFirstName = blc.CustomerFirstName,
                CustomerLastName = blc.CustomerLastName,
                CustomerCity = blc.CustomerCity,
                CustomerAddress = blc.CustomerAddress,
                CustomerPhone = blc.CustomerPhone,
                CustomerEmail = blc.CustomerEmail != null ? blc.CustomerEmail : "",
            };
            return c;
        }
        #endregion

        #region customerTobl
        public static BLCustomer customerTobl(Customer c)
        {
            if (c != null)
            {
                BLCustomer bla = new BLCustomer()
                {
                    CustomerId = c.CustomerId,
                    CustomerFirstName = c.CustomerFirstName,
                    CustomerLastName = c.CustomerLastName,
                    CustomerCity = c.CustomerCity,
                    CustomerAddress = c.CustomerAddress,
                    CustomerPhone = c.CustomerPhone,
                    CustomerEmail = c.CustomerEmail != null ? c.CustomerEmail : "",

                };
                return bla;
            }
            return null;
        }
        #endregion

        #region apartmentDetailsTodal
        public static ApartmentDetail apartmentDetailsTodal(BLApartmentDetails a)
        {
            ApartmentDetail bla = new ApartmentDetail()
            {
                ApartmentId = a.ApartmentId,
                AirDirections = a.AirDirections,
                ApartmentAddress = a.ApartmentAddress,
                ApartmentCity = a.ApartmentCity,
                Directions = a.Directions,
                ApartmentSize = a.ApartmentSize,
                Elevator = a.Elevator,
                Floor = a.Floor,
                CustomerId = a.CustomerId
            };
            return bla;
        }

        #endregion

        #region apartmentDetailsTobl
        public static BLApartmentDetails apartmentDetailsTobl(ApartmentDetail a)
        {
            BLApartmentDetails bla = new BLApartmentDetails()
            {
                ApartmentId = a.ApartmentId,
                AirDirections = a.AirDirections,
                ApartmentAddress = a.ApartmentAddress,
                ApartmentCity = a.ApartmentCity,
                Directions = a.Directions,
                ApartmentSize = a.ApartmentSize,
                Elevator = a.Elevator,
                Floor = a.Floor,
                CustomerId = a.CustomerId
            };
            return bla;
        }
        #endregion

        #region chatTodal
      public static  Chat  chatTodal(BLChat chat)
        {
            Chat c = new Chat()
            {

                ChatId = chat.ChatId,
                ApplicationId = chat.ApplicationId,
                Read = chat.Read,
                From = chat.From,
                SendDate = chat.SendDate,
                Information = chat.Information,
                To = chat.To,
            };
            return c;
        }

        #endregion

        #region chatTobl
        public  static BLChat chatTobl(Chat chat)
        {
            if (chat != null)
            {
                BLChat ch = new BLChat()
                {
                    ChatId = chat.ChatId,
                    ApplicationId = (int)chat.ApplicationId,
                    Read = (bool)chat.Read,
                    SendDate = chat.SendDate,
                    From = chat.From,
                    Information = chat.Information,
                    To = chat.To,
                };
                return ch;
            }
            return null;
        }

        #endregion
    }
}
