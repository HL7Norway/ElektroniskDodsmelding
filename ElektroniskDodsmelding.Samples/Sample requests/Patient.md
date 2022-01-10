## Patient sample request
Valid Patient that creates a death message registration.


Request: POST http://{environment}/Patient/
```json
{
  "resourceType": "Patient",
  "identifier": [
    {
      "use": "usual",
      "system": "urn:oid:2.16.578.1.12.4.1.4.1",
      "value": "24047230752"
    }
  ],
  "deceasedDateTime": "2021-11-06T10:11:00+01:00",
  "generalPractitioner" : [
      {
      "reference": "PractitionerRole/3024"
   }
  ]
}
```

Response: HttpStatus 201(Created)
```json
{
    "resourceType": "Patient",
    "id": "1028",
    "identifier": [
        {
            "system": "urn:oid:2.16.578.1.12.4.1.4.1",
            "value": "24047230752"
        }
    ],
    "deceasedDateTime": "2021-11-06T00:00:00+01:00"
}
```