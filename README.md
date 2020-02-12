# WingsOn Trial Project

### My Implementation Notes
* DAL layer is just a fake implementation, as before. (If I find time; I may replace it with at least EF Core+ SQLLite pair.)
* I converted Flight aggregate to an entity inside Booking entity. 
  * Flight entity should belong to a Booking as it also has Price attribute. (Probably booking class is also different from other bookings.)
* I created two new entities Customer and Passenger as they are not fully related; even if their properties are same for now.
  * It is also better to differentiate different roles and objects expilictly in the domain.
* I created a Passenger entity which also sits inside Booking entity.
  * Passenger entity should belong to a Booking as in reality there can not be a passenger without Booking.
* Business rules and validations need refinements and improvements, especially w.r.t flight domain rukles. 
  * I only checked some rules and validations for demonstration.
* I did not write unit or integration tests for Airports and Airlines contexts to save time for other core contexts.
* For DAL layer, I just tested RepositorBase; which covers most of the scenarios.

### Authentication

* For testing and demo purposes, you can create a token using <https://jwt.io> with your secret.
  * Or use the default secret `***SUPER SECRET KEY***` and default issuer `https://wingson.local`.
* Subject(sub), Issuer(iss) and Expiration(exp) fields are required in the jwt token.

### To Do

- [x] Default Jwt Authentication + Cors
- [x] Swashbuckle
- [x] Unit test and integration test projects
- [ ] ApplicationLayer Validation with Fluent Validation 
- [ ] Logging with Serilog
- [ ] Develop and throw custom specific exception classes rather then builtin framework exceptions.
- [ ] Use AutoFixture instead of creasting test objects manually.
- [ ] Put validation logic in Domain layer into specific validator/business-rule objects.
- [ ] Improve authentication with roles/scopes
- [ ] Resolve all build warnings.
- [ ] Extra: Add SQLLite persistency with Ef Core 
- [ ] Extra: Separate sample data project (Initial Dal project)
- [ ] Extra : Use autofac and autofac modules. Put related dependencies inside its own module.
- [ ] Extra : Abstract away MediatR library; introduce custom command/query dispatchers.
- [ ] Prod : Restrict Cors hosts, if required.
- [ ] Prod : Integrate with IdentityServer or an Idp; get secretkey from environment variable.
- [ ] Prod : Setup monitoring and healtcheck. (E.g. RunScope, PRTG, NewRelics, Graylog/ELK alerts etc.)
- [ ] Prod : Setup Azure CI/CD. Run unit & integration tests. Run and check code coverage. Deploy to feature based Azure Websites.

### Authentication

* For testing and demo purposes, you can create a token using <https://jwt.io> with your secret. (Or with the default secret)
* Subject(sub), Issuer(iss) and Expiration(exp) fields are required in the jwt token.

