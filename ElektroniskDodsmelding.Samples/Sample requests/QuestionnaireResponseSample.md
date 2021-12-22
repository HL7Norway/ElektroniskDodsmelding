## QuestionnaireResponse sample request
Valid QuestionnaireResponse that creates a cause of death registration. Returns a cause of death summary. 


Request: POST http://{environment}/QuestionnaireResponse/
```json
{
    "resourceType": "QuestionnaireResponse",
    "questionnaire": "/Questionnaire/1",
    "status": "completed",
    "subject": {
        "reference": "Patient/1028"
    },
    "author": {
        "reference": "PractitionerRole/3024"
    },
    "item": [
        {
            "linkId": "1_timeOfDeath_group",
            "item": [
                {
                    "linkId": "timeOfDeath",
                    "answer": [
                        {
                            "valueTime": "10:00:00"
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "2_placeOfDeath_group",
            "item": [
                {
                    "linkId": "placeOfDeath",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "99003",
                                "code": "5"
                            }
                        }
                    ]
                },
                {
                    "linkId": "municipality",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "3402",
                                "code": "0301",
                                "display": "Oslo"
                            }
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "3_causeOfDeath_group",
            "item": [
                {
                    "linkId": "causeOfDeath_question_A_code",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "7110",
                                "code": "A010",
                                "display": "Tyfoidfeber"
                            }
                        }
                    ]
                },
                {
                    "linkId": "causeOfDeath_question_A_time",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "1",
                                "display": "0-7 dager"
                            }
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "4_additionalInfoAboutDamage_group",
            "item": [
                {
                    "linkId": "additionalInfoAboutDamage_q1",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "2",
                                "display": "Nei"
                            }
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "5_operation_group",
            "item": [
                {
                    "linkId": "operation_impact_on_death",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "2",
                                "display": "Nei"
                            }
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "6_classification_group",
            "item": [
                {
                    "linkId": "classification_death",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "99000",
                                "code": "1",
                                "display": "Naturlig død"
                            }
                        }
                    ]
                },
                {
                    "linkId": "classification_autopsy",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "9",
                                "display": "Vet ikke"
                            }
                        }
                    ]
                },
                {
                    "linkId": "classification_reevaluate",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "9",
                                "display": "Vet ikke"
                            }
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "7_obligation_to_notify",
            "item": [
                {
                    "linkId": "report_unnatural",
                    "answer": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "9",
                                "display": "Vet ikke"
                            }
                        }
                    ]
                }
            ]
        }
    ]
}
```

Response: HttpStatus 201(Created)
```json
{
    "resourceType": "QuestionnaireResponse",
    "id": "b4e8d4cb-9a3a-41c2-8297-f11199b5bb54",
    "questionnaire": "1",
    "status": "completed",
    "subject": {
        "reference": "https://dodsmelding-fhir.utvikling.nhn.no/Patient/1028"
    },
    "authored": "2021-12-20T18:35:20.4396618+01:00",
    "author": {
        "reference": "https://dodsmelding-fhir.utvikling.nhn.no/PractitionerRole/3024"
    }
}
```