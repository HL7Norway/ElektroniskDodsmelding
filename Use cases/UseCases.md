## Use cases

### Register death message
Sending a death message is initiated by searching for a Patient based on its Identifier (either FNR or DNR), which will return a Bundle object containing matching Patients. 

Then, if a PractitionerRoleID for the registering user is not available, a PractitionerRole object with contact information should be posted to receive one.

Finally, the patient should be posted with a valid Identifier, DeceasedDate, and PractitionerRoleID, which will send the information to the Norwegian tax office and return the Patient object including its PatientID.

![](../Pictures/register_death_message_sequence_diagram.png "Sequence diagram of registering a death message")

### Register cause of death
Sending a cause of death message starts by calling a GET on the Questionnaire resource, which contains information about the questions and possible answers. 

The QuestionnaireResponse should contain the QuestionnaireID, PatientID, PractitionerRoleID. Posting it will send the answers to FHI, and return the same object with a QuestionnaireResponseID.

![](../Pictures/register_cause_of_death_sequence_diagram.png "Sequence diagram of registering a cause of death message")


***
**Note**: The answerValueSet of the questions asking directly about cause of death is quite large (~22000 codes) and is frequently updated by FHI. It therefore refers to a separate endpoint which will return the ValueSet. 

**Questionnaire example**
Sending a GET request to http://{environment}/Questionnaire/1 will return the cause of death questionnaire in JSON-format. Only one question is shown here for brevity, but the whole response can be found [here](../ElektroniskDodsmelding.Samples/Sample%20requests/QuestionnaireSample.md).

A couple of things to note:
* The questionnaire uses the FHIR extension [constraint](http://hl7.org/fhir/StructureDefinition/questionnaire-constraint) in order to enforce some of the more complex rules, e.g. at least one cause of death must be registered.
* The questionnaire items are structured in a hierarchical manner. Each item in the outermost layer are of type group and contains related questions. 
* The set of possible answers is included in most of the questions through the answerOption field. The exceptions are the ICD-10 and municipality code sets, which due to their size use the answerValueSet field. It contains the absolute URL to the endpoint for searching in the code sets. 
```json
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
        ...
    ]
}
```

***