using System;
using System.Collections.Generic;
using ElektroniskDodsmelding.Samples.Tests.Constants;
using Hl7.Fhir.Model;

namespace ElektroniskDodsmelding.Samples.Tests
{
    internal class TestResources
    {
        internal static PractitionerRole ValidPractitionerRole = new ()
        {
            Organization = new ResourceReference(null, "ElektroniskDodsmelding.Samples Test Hospital"),
            Location = new List<ResourceReference>
            {
                new(null,"Building A")
            },
            Telecom = new List<ContactPoint>()
            {
                new (ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "t@test.no"),
                new (ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "007007")
            }
        };

        /// <summary>
        /// Valid person that is alive in Test PREG.
        /// FNR: 16047508839
        /// Name: ROBERT STEFANI
        /// </summary>
        internal static Patient ValidPatient = new ()
        {
            Identifier = new List<Identifier>()
            {
                new (Constants.Constants.Identifier.FNRSystem, "16047508839")
            },
            Deceased = new FhirDateTime(new DateTimeOffset(DateTime.Now.Date)),
            GeneralPractitioner = null
        };

        internal static QuestionnaireResponse ValidQuestionnaireResponseWithRequiredAnswers(string practitionerRoleId, string patientId)
        {
            var questionnaireResponse = new QuestionnaireResponse();
            questionnaireResponse.Questionnaire = "Questionnaire/1";
            questionnaireResponse.Status = QuestionnaireResponse.QuestionnaireResponseStatus.Completed;
            questionnaireResponse.Author = new ResourceReference("PractitionerRole/" + practitionerRoleId);
            questionnaireResponse.Subject = new ResourceReference("Patient/" + patientId);
            
            var timeOfDeath_group = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "1_timeOfDeath_group",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.TimeOfDeath, new Time("10:00:00"))
                }
            };

            var placeOfDeath_group = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "2_placeOfDeath_group",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.PlaceOfDeath, new Coding(((int)OId.Dodssted).ToString(), "5")),
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.Municipality, new Coding(((int)OId.Kommune).ToString(), "0301", "Oslo"))
                }
            };

            var causeOfDeath_group = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "3_causeOfDeath_group",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.CauseOfDeath_question_A_code, new Coding(((int)OId.ICD10).ToString(), "A010", "Tyfoidfeber")),
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.CauseOfDeath_question_A_time, new Coding(((int)OId.VarighetSykdom).ToString(), "1", "0-7 dager"))
                }
            };

            var additionalInfoAboutDamage_group = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "4_additionalInfoAboutDamage_group",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.AdditionalInfoAboutDamage_q1, new Coding(((int)OId.JaNeiVetIkke).ToString(), "2", "Nei"))
                }
            };

            var operation_group = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "5_operation_group",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.Operation_impact_on_death, new Coding(((int)OId.JaNeiVetIkke).ToString(), "2", "Nei"))
                }
            };

            var classification_group = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "6_classification_group",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.Classification_death, new Coding(((int)OId.Dodsmate).ToString(), "1", "Naturlig død")),
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.Classification_autopsy, new Coding(((int)OId.JaNeiVetIkke).ToString(), "2", "Nei")),
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.Classification_reevaluate, new Coding(((int)OId.JaNeiVetIkke).ToString(), "9", "Vet ikke"))
                }
            };

            var obligation_to_notify = new QuestionnaireResponse.ItemComponent
            {
                LinkId = "7_obligation_to_notify",
                Item = new List<QuestionnaireResponse.ItemComponent>
                {
                    CreateItemComponentWithAnswer(CauseOfDeathLinkId.Report_unnatural, new Coding(((int)OId.JaNeiVetIkke).ToString(), "2", "Nei"))
                }
            };

            questionnaireResponse.Item.Add(timeOfDeath_group);
            questionnaireResponse.Item.Add(placeOfDeath_group);
            questionnaireResponse.Item.Add(causeOfDeath_group);
            questionnaireResponse.Item.Add(additionalInfoAboutDamage_group);
            questionnaireResponse.Item.Add(operation_group);
            questionnaireResponse.Item.Add(classification_group);
            questionnaireResponse.Item.Add(obligation_to_notify);

            return questionnaireResponse;
        }

        private static QuestionnaireResponse.ItemComponent CreateItemComponentWithAnswer(string linkId, Coding codeAnswer)
        {
            return new QuestionnaireResponse.ItemComponent()
            {
                LinkId = linkId,
                Answer = new List<QuestionnaireResponse.AnswerComponent>
                {
                    new()
                    {
                        Value = codeAnswer
                    }
                }
            };
        }
        private static QuestionnaireResponse.ItemComponent CreateItemComponentWithAnswer(string linkId, Time timeAnswer)
        {
            return new QuestionnaireResponse.ItemComponent()
            {
                LinkId = linkId,
                Answer = new List<QuestionnaireResponse.AnswerComponent>
                {
                    new()
                    {
                        Value = timeAnswer
                    }
                }
            };
        }
    }
}
