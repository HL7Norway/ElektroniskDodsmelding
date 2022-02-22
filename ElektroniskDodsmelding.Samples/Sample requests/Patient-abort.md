## Patient sample request
Abort a death message registration. Will throw errors if the person is not reported as dead.


Request: POST http://fhir-dodsmelding.{environment}.nhn.no/Patient/
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
  "deceasedBoolean": "false",
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
    "deceasedBoolean": false
}
```