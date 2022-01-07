## PractitionerRole sample request
Create contact details for the signed in doctor.
Will only create new PractitionerRole if the contact details do not exist otherwise return the existing PractitionerRole.


Request: POST http://{environment}/PractitionerRole/
```json
{
    "resourceType": "PractitionerRole",
    "organization": {
        "display":  "Test Sykehuset"
    },
    "location": [
        {
            "display": "Avdeling ABC"
        }
    ],
    "telecom": [
        {
            "system": "email",
            "value": "tes@test.no"
        },
        {
            "system": "phone",
            "value": "007007"
        }
    ]
}
```

Response:
```json
{
    "resourceType": "PractitionerRole",
    "id": "3028",
    "organization": {
        "display": "Test Sykehuset"
    },
    "location": [
        {
            "display": "Avdeling ABC"
        }
    ],
    "telecom": [
        {
            "system": "email",
            "value": "tes@test.no"
        },
        {
            "system": "phone",
            "value": "007007"
        }
    ]
}
```

> **Note:**
> * Reference to the PractitionerRole is needed to create both Patient and QuestionnaireResponse. 
> * A reference to the created resources above looks like this: PractitionerRole/3028. The signed in doctor can only use PractitionerRole related to himself.
> * GET http://{environment}/PractitionerRole/{id} is also available.