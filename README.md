# WingsOn Trial Project

### Important Notes
* DAL layer is just a fake implementation. (If I find time; I may replace it with at least EF Core+ SQLLite pair.)

### Authentication

* For testing and demo purposes, you can create a token using <https://jwt.io> with your secret. (Or with the default secret)
* Subject(sub), Issuer(iss) and Expiration(exp) fields are required in the jwt token.

### To Do

- [x] Default Jwt Authentication + Cors
- [x] Swashbuckle
- [ ] Unit test and integration test projects
- [ ] Validation 
- [ ] Logging
- [ ] Improve authentication with roles/scopes
- [ ] Resolve all build warnings.
- [ ] Extra: Add SQLLite persistency with Ef Core 
- [ ] Extra: Separate sample data project (Initial Dal project)

### To Do - Real Life
- [ ] Use autofac and autofac modules. Put related dependencies inside its own module.
- [ ] Abstract away MediatR library; introduce custom command/query dispatchers.
- [ ] Restrict Cors hosts, if required.
- [ ] Integrate with IdentityServer; get secretkey from environment variable.
- [ ] Setup monitoring and healtcheck. (E.g. RunScope, PRTG, NewRelics, Graylog/ELK alerts etc.)
- [ ] Setup Azure CI/CD. Run unit & integration tests. Run and check code coverage. Deploy to feature based Azure Websites.   

### Authentication

* For testing and demo purposes, you can create a token using <https://jwt.io> with your secret. (Or with the default secret)
* Subject(sub), Issuer(iss) and Expiration(exp) fields are required in the jwt token.

