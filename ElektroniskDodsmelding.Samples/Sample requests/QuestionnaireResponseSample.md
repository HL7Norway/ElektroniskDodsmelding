## QuestionnaireResponse sample request
Valid QuestionnaireResponse that creates a cause of death registration. Returns a cause of death summary. 


Request: POST http://{environment}/Questionnaire/
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
            "linkId": "timeOfDeath_group",
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
            "linkId": "placeOfDeath_group",
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
            "linkId": "causeOfDeath_group",
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
            "linkId": "additionalInfoAboutDamage_group",
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
            "linkId": "operation_group",
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
                },
                {
                    "linkId": "operation_time",
                    "answer": [
                        {
                            "valueDate": "2021-01-01"
                        }
                    ]
                },
                {
                    "linkId": "operation_description",
                    "answer": [
                        {
                            "valueString": "Logotomert manuelt på utenlansk sykehus"
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "classification_group",
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
            "linkId": "report",
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