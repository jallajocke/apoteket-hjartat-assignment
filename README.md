# Apoteket Hjärtat Backend Assignment

More information on the assignment criterias can be found in the file '_Backend assignment Apotek Hjärtat.pdf_'.

## Prerequisites

- .NET 8

## Dependencies

The solution currently does not have any external dependencies.

**Warning**
The solution currently uses a scaffold repository. The storage is only in a List and is neither thread safe nor provides persistence after the application is running. It is not meant to be used other than to enable the application to run.

## Tests

### Unit Tests

The tests are ready to run in the Tests project. The coverage is far from complete. Some example tests are available for the Order class.

### Postman Requests

A few Postman requests has been added for the Create and Get endpoints. Tests have been added to validate the response. It can be used for integration tests. Just import the file in the Postman folder.

## Remaining Work

1. As mentioned above, the unit test coverage is lacking. Likewise the coverage of the Postman requests. Both of which should be extended.
1. Replacing the OrderRepositoryScaffold. Once done with the tests, the scaffold has served its purpose. The models and mappers could still be of use depending on which database is chosen.
1. Add logging.
