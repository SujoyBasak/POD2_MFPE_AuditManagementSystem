using AuditChecklistModule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Repository
{
    public class ChecklistRepo : IChecklistRepo
    {
        private static List<Questions> InternalQuestionsList = new List<Questions>()
        {
            new Questions
            {
                QuestionNo=1,
                Question="Have all Change requests followed SDLC before PROD move?"
            },
            new Questions
            {
                QuestionNo=2,
                Question="Have all Change requests been approved by the application owner?"
            },
            new Questions
            {
                QuestionNo=3,
                Question="Are all artifacts like CR document, Unit test cases available?"
            },
            new Questions
            {
                QuestionNo=4,
                Question="Is the SIT and UAT sign-off available?"
            },
            new Questions
            {
                QuestionNo=5,
                Question="Is data deletion from the system done with application owner approval?"
            }
        };

        private static List<Questions> SOXQuestionsList = new List<Questions>()
        {
            new Questions
            {
                QuestionNo=1,
                Question="Have all Change requests followed SDLC before PROD move?"
            },
            new Questions
            {
                QuestionNo=2,
                Question="Have all Change requests been approved by the application owner?"
            },
            new Questions
            {
                QuestionNo=3,
                Question="For a major change, was there a database backup taken before and after PROD move?"
            },
            new Questions
            {
                QuestionNo=4,
                Question="Has the application owner approval obtained while adding a user to the system?"
            },
            new Questions
            {
                QuestionNo=5,
                Question="Is data deletion from the system done with application owner approval?"
            }
        };
        

        public List<Questions> GetQuestions(string auditType)
        {
            List<Questions> ls = new List<Questions>();

            if (auditType == "Internal")
                ls = InternalQuestionsList;
            else if (auditType == "SOX")
                ls = SOXQuestionsList;
            else
                return null;
            
              return ls;

            
        }

        
    }
}
