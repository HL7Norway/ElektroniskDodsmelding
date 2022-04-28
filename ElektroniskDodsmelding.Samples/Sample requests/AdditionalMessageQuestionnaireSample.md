## Additional message Questionnaire sample request
The behavior of the questionnaire can be explored using for example LHC's FHIR Questionnaire renderer: https://lhcforms.nlm.nih.gov/lhcforms

The schema presents question(s) requested by a caseworker at the the National Institute of Public Health.

Request: GET http://fhir-dodsmelding.{environment}.nhn.no/Questionnaire/s0af5f25-e7d9-46d5-a8db-3cadbcd55555

Response:
```json
{
    "resourceType": "Questionnaire",
    "id": "s0af5f25-e7d9-46d5-a8db-3cadbcd55555",
    "extension": [
        {
            "url": "http://nhn.no/dodsmelding/fhir/StructureDefinition/AdditionTo",
            "valueReference": {
                "reference": "https://fhir-dodsmelding.test.nhn.no/QuestionnaireResponse/e0af5f25-e7d9-46d5-a8db-3cadbcd55373"
            }
        }
    ],
    "name": "etterspurt_tilleggsmelding_1",
    "title": "Etterspurt tilleggsmelding",
    "status": "active",
    "item": [
        {
            "linkId": "caseworker",
            "text": "Saksbehandler hos Folkehelseinstituttet",
            "type": "group",
            "item": [
                {
                    "linkId": "caseworkerName",
                    "text": "Line Koder",
                    "type": "display"
                },
                {
                    "linkId": "caseworkerPhone",
                    "text": "007007",
                    "type": "display"
                }
            ]
        },
        {
            "linkId": "additionalMessage",
            "text": "Spørsmål til registrert dødsmelding",
            "type": "group",
            "item": [
                {
                    "linkId": "additionalMessage_1",
                    "definition": "Hjerte og blodårer",
                    "text": "Hadde pasienten Hjerteflimmer (arterieflimmer) i forkant?",
                    "type": "text",
                    "required": true
                }
            ]
        }
    ]
}
```