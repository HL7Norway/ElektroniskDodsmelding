## Questionnaire sample request

Request: GET http://{environment}/Questionnaire/1

Response:
´´´
{
    "resourceType": "Questionnaire",
    "id": "1",
    "meta": {
        "versionId": "1.0"
    },
    "extension": [
        {
            "extension": [
                {
                    "url": "key",
                    "valueString": "MinstEtArsaksfeltSkalVæreUtfylt"
                },
                {
                    "url": "severity",
                    "valueString": "error"
                },
                {
                    "url": "human",
                    "valueString": "Minst ett årsaksfelt skal være utfylt"
                },
                {
                    "url": "expression",
                    "valueString": "%resource.repeat(item).where(linkId='3_causeOfDeath_group').item.where(answer.hasValue()).count() > 0"
                }
            ],
            "url": "http://hl7.org/fhir/StructureDefinition/questionnaire-constraint"
        }
    ],
    "name": "dodsaarsak_1",
    "title": "Dødsårsak",
    "status": "draft",
    "publisher": "Norsk helsenett",
    "description": "Skjema for å fylle ut en dødsårsak som er knyttet til et dødsfall",
    "purpose": "Skjema som skal utfylles av lege ved et dødsfall for å registrere dødsårsak til FHI",
    "item": [
        {
            "linkId": "1_timeOfDeath_group",
            "text": "Klokkeslett for dødsfall",
            "type": "group",
            "item": [
                {
                    "linkId": "timeOfDeath",
                    "text": "Hvis kjent, når omtrent på døgnet inntraff døden? Rund av hvis du er usikker.",
                    "type": "time",
                    "required": true,
                    "repeats": false
                }
            ]
        },
        {
            "linkId": "2_placeOfDeath_group",
            "text": "Dødssted",
            "type": "group",
            "item": [
                {
                    "linkId": "placeOfDeath",
                    "text": "Dødssted",
                    "type": "choice",
                    "required": true,
                    "repeats": false,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99003",
                                "code": "5",
                                "display": "Privat hjem - Områder som betraktes som hjemmeområder for avdøde med unntak av helseinstitusjoner; hus, leilighet, fritidsbolig, parkert bobil/campingvogn, hage, garasje, privat svømmebasseng o.l"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99003",
                                "code": "1",
                                "display": "Sykehus - Inkluderer alle avdelingstyper på sykehus, både somatiske og psykiatriske sykehus"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99003",
                                "code": "4",
                                "display": "Annen helseinstitusjon - Inkluderer alle typer pleie- og omsorgsinstitusjoner som bo- og behandlingssenter, bofellesskap, dagsenter, bo- og aktivitetssenter i tillegg til sykestuer, medisinske sentre, rehabiliteringssenter o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99003",
                                "code": "8",
                                "display": "Annet - Inkluderer offentlige rom, ute i naturen, på sjøen/havet, under transport til sykehus, i utlandet, i fengsel, i militæret o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99003",
                                "code": "10",
                                "display": "Ikke kjent"
                            }
                        }
                    ]
                },
                {
                    "linkId": "institution",
                    "text": "Hva er navnet på institusjonen dødsfallet er meldt fra?",
                    "type": "string",
                    "enableWhen": [
                        {
                            "question": "placeOfDeath",
                            "operator": "=",
                            "answerCoding": {
                                "system": "99003",
                                "code": "4",
                                "display": "Annen helseinstitusjon - Inkluderer alle typer pleie- og omsorgsinstitusjoner som bo- og behandlingssenter, bofellesskap, dagsenter, bo- og aktivitetssenter i tillegg til sykestuer, medisinske sentre, rehabiliteringssenter o.l."
                            }
                        }
                    ],
                    "required": true,
                    "maxLength": 220
                },
                {
                    "linkId": "institution_unknown_checkbox",
                    "text": "Vet ikke",
                    "type": "boolean",
                    "enableWhen": [
                        {
                            "question": "placeOfDeath",
                            "operator": "=",
                            "answerCoding": {
                                "system": "99003",
                                "code": "4",
                                "display": "Annen helseinstitusjon - Inkluderer alle typer pleie- og omsorgsinstitusjoner som bo- og behandlingssenter, bofellesskap, dagsenter, bo- og aktivitetssenter i tillegg til sykestuer, medisinske sentre, rehabiliteringssenter o.l."
                            }
                        }
                    ]
                },
                {
                    "linkId": "municipality",
                    "text": "I hvilken kommune døde personen?",
                    "type": "choice",
                    "required": true,
                    "answerValueSet": "http://host.docker.internal:61517/api/koder?oid=3402&query={query}"
                },
                {
                    "linkId": "municipality_unknown_checkbox",
                    "text": "Vet ikke",
                    "type": "boolean"
                }
            ]
        },
        {
            "linkId": "3_causeOfDeath_group",
            "text": "Dødsårsak",
            "type": "group",
            "item": [
                {
                    "linkId": "causeOfDeath_question_text",
                    "text": "Hva var årsaken, eller sekvensen av årsaker, som førte til dødsfallet?",
                    "type": "display"
                },
                {
                    "linkId": "causeOfDeath_question_help_text",
                    "text": "Diagnosene du velger på A/B/C/D skal gjenspeile sekvensen av årsaker som ledet til døden, dvs. fra de bakenforliggende dødsårsakene (B/C/D) til den umiddelbare dødsårsaken (A). Terminale diagnoser slik som hjertestans, arrytmi eller kardiorespiratorisk svikt skal ikke velges.",
                    "type": "display"
                },
                {
                    "linkId": "causeOfDeath_question_A_code",
                    "text": "Umiddelbar dødsårsak A",
                    "type": "choice",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_A_text",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": true,
                    "answerValueSet": "http://host.docker.internal:61517/api/koder?oid=7110&query={query}"
                },
                {
                    "linkId": "causeOfDeath_question_A_text",
                    "text": "Umiddelbar dødsårsak A (Fritekst)",
                    "type": "text",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_A_code",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": true
                },
                {
                    "linkId": "causeOfDeath_question_A_time",
                    "text": "Ca. tid mellom begynnelse og døden.",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "1",
                                "display": "0-7 dager"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "2",
                                "display": "1 uke – 1 måned"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "3",
                                "display": "1 måned – 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "4",
                                "display": "Mer enn 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "0",
                                "display": "Medfødt"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "5",
                                "display": "Ukjent"
                            }
                        }
                    ]
                },
                {
                    "linkId": "causeOfDeath_question_B_code",
                    "text": "Som følge av B",
                    "type": "choice",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_B_text",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": false,
                    "answerValueSet": "http://host.docker.internal:61517/api/koder?oid=7110&query={query}"
                },
                {
                    "linkId": "causeOfDeath_question_B_text",
                    "text": "Som følge av B (Fritekst)",
                    "type": "text",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_B_code",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": false
                },
                {
                    "linkId": "causeOfDeath_question_B_time",
                    "text": "Ca. tid mellom begynnelse og døden.",
                    "type": "choice",
                    "required": false,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "1",
                                "display": "0-7 dager"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "2",
                                "display": "1 uke – 1 måned"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "3",
                                "display": "1 måned – 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "4",
                                "display": "Mer enn 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "0",
                                "display": "Medfødt"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "5",
                                "display": "Ukjent"
                            }
                        }
                    ]
                },
                {
                    "linkId": "causeOfDeath_question_C_code",
                    "text": "Som følge av C",
                    "type": "choice",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_C_text",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": false,
                    "answerValueSet": "http://host.docker.internal:61517/api/koder?oid=7110&query={query}"
                },
                {
                    "linkId": "causeOfDeath_question_C_text",
                    "text": "Som følge av C (Fritekst)",
                    "type": "text",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_C_code",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": false
                },
                {
                    "linkId": "causeOfDeath_question_C_time",
                    "text": "Ca. tid mellom begynnelse og døden.",
                    "type": "choice",
                    "required": false,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "1",
                                "display": "0-7 dager"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "2",
                                "display": "1 uke – 1 måned"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "3",
                                "display": "1 måned – 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "4",
                                "display": "Mer enn 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "0",
                                "display": "Medfødt"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "5",
                                "display": "Ukjent"
                            }
                        }
                    ]
                },
                {
                    "linkId": "causeOfDeath_question_D_code",
                    "text": "Som følge av D",
                    "type": "choice",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_D_text",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": false,
                    "answerValueSet": "http://host.docker.internal:61517/api/koder?oid=7110&query={query}"
                },
                {
                    "linkId": "causeOfDeath_question_D_text",
                    "text": "Som følge av D (Fritekst)",
                    "type": "text",
                    "enableWhen": [
                        {
                            "question": "causeOfDeath_question_D_code",
                            "operator": "exists",
                            "answerBoolean": false
                        }
                    ],
                    "required": false
                },
                {
                    "linkId": "causeOfDeath_question_D_time",
                    "text": "Ca. tid mellom begynnelse og døden.",
                    "type": "choice",
                    "required": false,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "1",
                                "display": "0-7 dager"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "2",
                                "display": "1 uke – 1 måned"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "3",
                                "display": "1 måned – 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "4",
                                "display": "Mer enn 1 år"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "0",
                                "display": "Medfødt"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99004",
                                "code": "5",
                                "display": "Ukjent"
                            }
                        }
                    ]
                },
                {
                    "linkId": "causeOfDeath_question_secondary_code",
                    "text": "Medvirkende dødsårsak",
                    "type": "choice",
                    "required": false,
                    "repeats": true,
                    "answerValueSet": "http://host.docker.internal:61517/api/koder?oid=7110&query={query}"
                }
            ]
        },
        {
            "linkId": "4_additionalInfoAboutDamage_group",
            "text": "Tilleggsopplysninger om skade",
            "type": "group",
            "item": [
                {
                    "linkId": "additionalInfoAboutDamage_q1",
                    "text": "Er noen av dødsårsakene forårsaket av skade eller forgiftning?",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        },
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
                    "linkId": "additionalInfoAboutDamage_q1_help_text",
                    "text": "For eksempel: Brannskade, bruddskade, indre skade, blødning, kvelning, kullosforgiftning, legemiddelforgiftning, «overdose» av rusmiddel. Husk at enkelte tilstander som f.eks multiorgansvikt, lungeemboli, sepsis, lungebetennelse og hypoksisk hjerneskade kan være forårsaket av en skade eller forgiftning.",
                    "type": "display"
                },
                {
                    "linkId": "additionalInfoAboutDamage_timeOfDamage",
                    "text": "Når skjedde skaden?",
                    "type": "date",
                    "enableWhen": [
                        {
                            "question": "additionalInfoAboutDamage_q1",
                            "operator": "=",
                            "answerCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        }
                    ],
                    "required": true
                },
                {
                    "linkId": "additionalInfoAboutDamage_description",
                    "text": "Beskriv kort omstendighetene rundt skaden",
                    "type": "text",
                    "enableWhen": [
                        {
                            "question": "additionalInfoAboutDamage_q1",
                            "operator": "=",
                            "answerCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        }
                    ],
                    "required": true,
                    "maxLength": 220
                },
                {
                    "linkId": "additionalInfoAboutDamage_place",
                    "text": "På hvilket sted skjedde skaden?",
                    "type": "choice",
                    "enableWhen": [
                        {
                            "question": "additionalInfoAboutDamage_q1",
                            "operator": "=",
                            "answerCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        }
                    ],
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "0",
                                "display": "Privat hjem - Hjemmeområde, hage, garasje, privat svømmebasseng, leilighet, hytte o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "1",
                                "display": "Langtidsbolig - Barnehjem, hospice, militærleir, pleie- og omsorgsbolig, fengsel o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "2",
                                "display": "Offentlig sted - Sykehus, barnehage, teater, museum, kirke, bibliotek, skole o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "3",
                                "display": "Sportsarena - Alpinanlegg, svømmehall, treningssenter, golfbane, fotballstadion o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "4",
                                "display": "Gate/vei - Vei, fortau o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "5",
                                "display": "Handel/service - Flyplass, bank, kafe, hotell, butikk, bensinstasjon, buss,- og jernbanestasjon, ferjekai o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "6",
                                "display": "Industrielt anlegg - Byggeplass, oljerigg, fabrikk, bergverk o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "7",
                                "display": "Landbruk - Bondegård o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "8",
                                "display": "Annet sted - Hvis du velger denne, forklar nærmere i beskrivelsen"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99005",
                                "code": "9",
                                "display": "Ukjent sted"
                            }
                        }
                    ]
                },
                {
                    "linkId": "additionalInfoAboutDamage_activity",
                    "text": "Hva slags aktivitet holdt avdøde på med?",
                    "type": "choice",
                    "enableWhen": [
                        {
                            "question": "additionalInfoAboutDamage_q1",
                            "operator": "=",
                            "answerCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        }
                    ],
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "0",
                                "display": "Sportsaktivitet - Golf, fotball, riding, ski, svømming, vannski , kajakk o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "1",
                                "display": "Fritidsaktivitet - Hobbyaktiviteter, kino, dans, deltagelse i frivillige organisasjoner o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "2",
                                "display": "Inntektsgivende arbeid - Betalt arbeid, reise i tilknytning til arbeid"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "3",
                                "display": "Ubetalt arbeid, under utdanning  - Husarbeid, jobbe i hagen, barnepass, skole o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "4",
                                "display": "Dagliglivsaktiviteter (ADL) - Hvile, spise, sove, personlig hygiene o.l."
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "8",
                                "display": "Annen aktivitet - Hvis du velger denne, forklar nærmere i beskrivelsen"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99006",
                                "code": "9",
                                "display": "Ukjent aktivitet"
                            }
                        }
                    ]
                }
            ]
        },
        {
            "linkId": "5_operation_group",
            "text": "Operasjon",
            "type": "group",
            "item": [
                {
                    "linkId": "operation_impact_on_death",
                    "text": "Har avdøde gjennomgått en operasjon av betydning for dødsfallet?",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        },
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
                    "text": "Når ble avdøde operert (ca.)?",
                    "type": "date",
                    "enableWhen": [
                        {
                            "question": "operation_impact_on_death",
                            "operator": "=",
                            "answerCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        }
                    ],
                    "required": true
                },
                {
                    "linkId": "operation_description",
                    "text": "Hva var årsaken til operasjonen og viktigste funn?",
                    "type": "text",
                    "enableWhen": [
                        {
                            "question": "operation_impact_on_death",
                            "operator": "=",
                            "answerCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        }
                    ],
                    "required": true,
                    "maxLength": 220
                }
            ]
        },
        {
            "linkId": "6_classification_group",
            "text": "Klassifisering av dødsfall",
            "type": "group",
            "item": [
                {
                    "linkId": "classification_death",
                    "text": "Hvordan ville du ha klassifisert dødsfallet?",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "99000",
                                "code": "1",
                                "display": "Naturlig død"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99000",
                                "code": "2",
                                "display": "Ulykke"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99000",
                                "code": "3",
                                "display": "Selvmord"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99000",
                                "code": "4",
                                "display": "Drap"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "99000",
                                "code": "9",
                                "display": "Ukjent"
                            }
                        }
                    ]
                },
                {
                    "linkId": "classification_info",
                    "text": "Det du krysser av på under pkt. 6 Klassifisering av dødsfall, blir automatisk registrert under pkt. 7 Meldeplikt ved unaturlig dødsfall.",
                    "type": "display"
                },
                {
                    "linkId": "classification_autopsy",
                    "text": "Blir det utført obduksjon?",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "2",
                                "display": "Nei"
                            }
                        },
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
                    "text": "Vil den oppgitte dødsårsaken senere bli revurdert?",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "2",
                                "display": "Nei"
                            }
                        },
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
            "text": "Meldeplikt ved unaturlig dødsfall",
            "type": "group",
            "item": [
                {
                    "linkId": "report_unnatural",
                    "text": "Kan dødsfallet anses som unaturlig?",
                    "type": "choice",
                    "required": true,
                    "answerOption": [
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "1",
                                "display": "Ja"
                            }
                        },
                        {
                            "valueCoding": {
                                "system": "1102",
                                "code": "2",
                                "display": "Nei"
                            }
                        },
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
                    "linkId": "report_info_1",
                    "text": "Dette anses som unaturlig: \ndrap eller annen legemskrenkelse \nselvmord eller selvvoldt skade \nulykke \nyrkesulykke eller yrkesskade \nfeil, forsømmelse eller uhell ved undersøkelse eller behandling av sykdom eller skade \nmisbruk av narkotika \nukjent årsak når døden har inntrådt plutselig og uventet \ndødsfall i fengsel eller under sivil eller militær arrest \ndødsfall for barn under 18 år utenfor institusjon",
                    "type": "display"
                },
                {
                    "linkId": "report_info_2",
                    "text": "Du plikter å gi politiet beskjed snarest mulig tlf. 02800 hvis det er grunn til å tro at dødsfallet er unaturlig, jf. helsepersonelloven paragraf 36 tredje ledd. \nHusk å sende signert legeerklæring til politiet.",
                    "type": "display"
                }
            ]
        }
    ]
}
´´´