# WingsOn Trial Project

### Important Notes
* DAL layer is just a fake implementation. If I find time; I will replace it at least with EF Core+ SQLLite pair.

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
- [ ] Extra: Set up Azure DevOps CI/CD
- [ ] Extra: Deploy to Azure Websites
- [ ] Extra: Show build status in GitHub
- [ ] Extra: Show test results in CI/CD
- [ ] Extra: Show code coverage in CI/CD
- [ ] Extra: Add SQLLite persistency with Ef Core
- [ ] Extra: Separate sample data project (Initial Dal project)
