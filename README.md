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
- [ ] Extra: Set up Azure DevOps CI/CD
- [ ] Extra: Deploy to Azure Websites
- [ ] Extra: Show build status in GitHub
- [ ] Extra: Show test results in CI/CD
- [ ] Extra: Show code coverage in CI/CD
- [ ] Extra: Abstract away MediatR library; introduce custom command/query dispatchers.
- [ ] Extra: Add SQLLite persistency with Ef Core 
- [ ] Extra: Separate sample data project (Initial Dal project)
- [ ] Extra: Create a client library project and publish as nuget package.
- [ ] Extra: SSO: Either add IdentityServer or custom trivial auth server project with login page.

### To Do - Before Production 
- [ ] Restrict Cors hosts, if required.
- [ ] Integrate with IdentityServer; get secretkey from environment variable.
- [ ] Setup monitoring and healtcheck. (E.g. RunScope, PRTG, NewRelics, Graylog/ELK alerts etc.)

### Authentication

* For testing and demo purposes, you can create a token using <https://jwt.io> with your secret. (Or with the default secret)
* Subject(sub), Issuer(iss) and Expiration(exp) fields are required in the jwt token.

