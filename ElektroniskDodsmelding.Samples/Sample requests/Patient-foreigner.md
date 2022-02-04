## Patient sample request
Valid Patient that does not have a FNR/DNR identifier. Also referred to as foreigners or PUF. Creates a death message registration.


Request: POST http://{environment}/Patient/
```json
{
    "resourceType": "Patient",
    "identifier": [
        {
            "use": "usual",
            "system": " ",
            "type": {
                "coding": [
                    {
                        "system": "https://api.helsepunkt.no/api/koder/8116",
                        "code": "DUF"
                    }
                ]
            },
            "value": "11111Asc"
        }
    ],
    "deceasedDateTime": "2021-10-02",
    "generalPractitioner": {
        "reference": "PractitionerRole/230"
    },
    "birthDate": "2001-10-01",
    "gender": "male",
    "name": [
        {
            "family": "Etternavn her",
            "given": [
                "Fornavn her",
                "Mellomnavn her"
            ]
        }
    ],
    "address": [
        {
            "country": "DK"
        }
    ],
    "extension": [
        {
            "url": "http://nhn.no/dodsmelding/fhir/StructureDefinition/ReasonForStay",
            "valueCodeableConcept": {
                "coding": [
                    {
                        "system": "https://api.helsepunkt.no/api/koder/99012",
                        "code": "3"
                    }
                ]
            }
        }
    ]
}
```

Response: HttpStatus 201(Created)
```json
{
    "resourceType": "Patient",
    "id": "1648",
    "identifier": [
        {
            "type": {
                "coding": [
                    {
                        "system": "https://api.helsepunkt.no/api/koder/8116",
                        "code": "DUF"
                    }
                ]
            },
            "value": "11111Asc"
        }
    ],
    "deceasedDateTime": "2021-10-02T00:00:00+02:00"
}
```