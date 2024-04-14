# Hash Slinger

![GitHub](https://img.shields.io/github/license/unclesp1d3r/HashSlinger)
![GitHub issues](https://img.shields.io/github/issues/unclesp1d3r/HashSlinger)
![GitHub Repo stars](https://img.shields.io/github/stars/unclesp1d3r/HashSlinger?style=social)
![GitHub last commit](https://img.shields.io/github/last-commit/unclesp1d3r/HashSlinger)
![Maintenance](https://img.shields.io/maintenance/yes/2023)
[![LoC](https://tokei.rs/b1/github/unclesp1d3r/HashSlinger?category=code)](https://github.com/unclesp1d3r/HashSlinger)
[![wakatime](https://wakatime.com/badge/github/unclesp1d3r/HashSlinger.svg)](https://wakatime.com/badge/github/unclesp1d3r/HashSlinger)

> :caution: **Project Archived** : This project is no being developed. We are working on a new project called [CipherSwarm](https://github.com/unclesp1d3r/CipherSwarm) which is a complete re-write of HashSlinger with more features and better performance.

Hash Slinger is a purpose-built wrapper for Hashcat, designed specifically to facilitate distributed hash cracking in high-speed, secure, and centralized network environments. By leveraging the power of multiple machines, Hash Slinger adeptly manages large quantities of hashes, aiming to optimize your hash cracking operations.

> :warning: **Development Status**: Please be informed that Hash Slinger is currently in an early phase of development and has not yet reached a stable release.

## Why Hash Slinger?

Hash Slinger was conceived to provide a specialized solution for large environments where the need for effective scaling across numerous machines, extensive rule sets, and substantial volumes of hashes is critical. It is tailored for high-trust environments where all cracking clients are controlled by the user and are interconnected via high-speed connections such as Local Area Networks (LANs).

Despite the effectiveness of Hashtopolis, we found that it could struggle to scale in environments typified by a high number of machines, extensive rule sets, and large volumes of hashes. Hash Slinger was born out of a need to overcome these challenges. It is specifically crafted for use in high-trust environments, where cracking clients are interconnected via secure, high-speed connections like Local Area Networks (LANs). In such scenarios, the user has control over all the cracking clients, thereby negating the need for use over the internet or the integration with anonymous systems serving as cracking clients.

While Hash Slinger is under active development, it is worth noting that like any actively developed software, there may be limitations or bugs that we are continuously working to address. Our team is committed to making Hash Slinger a robust tool that meets the rigorous demands of large Red Teams and penetration testing organizations.

A core goal of Hash Slinger's development is to ensure compatibility with the Hashtopolis Communication Protocol v2. This focus is geared towards facilitating a smooth transition for users considering migrating from Hashtopolis to Hash Slinger, ensuring the effective distribution of cracking jobs across multiple machines.

Unique features of Hash Slinger include:

- Support for uploading and downloading complete pot files for use in other cracking jobs.
- Capability to handle extensive rule sets and very large mask sets.
- Ability to assign systems to different projects, allowing prioritized job cracking based on project requirements.

Hash Slinger caters specifically to secure, centralized, and high-performance environments. By focusing on these scenarios, Hash Slinger offers scalable and efficient solutions for sophisticated cracking operations.

## Project Assumptions and Target Audience

Hash Slinger, while performing functions similar to Hashtopolis, is not a reiteration of the latter. It is a unique project, conceived with a specific target audience in mind and shaped by several guiding assumptions:

1. **Cracking Tool**: Hash Slinger exclusively supports Hashcat as the cracking tool.

2. **Connectivity**: It is assumed that all clients connected to Hash Slinger will use a reliable, high-speed connection, typically found in a Local Area Network (LAN) environment.

3. **Trust Level**: Hash Slinger operates under the assumption that all client machines are trustworthy and are under the direct control and management of the user utilizing Hash Slinger.

4. **User Base**: The system assumes that users, though having different levels of administrative access, belong to the same organization or project team, ensuring a level of trust and common purpose.

5. **Hashlist Management**: Hash Slinger is designed to handle hashlists derived from various projects or operations. It enables users to view results from specific projects or across all projects, depending on access privileges.

6. **Client-Project Affiliation**: Cracking clients can be associated with specific projects, executing operations solely for that project. Alternatively, they can be permitted to perform operations across all projects, with defined priorities for specific projects.

Hash Slinger is specifically crafted for medium to large-scale cracking infrastructure, interconnected via high-speed networks. It does not support utilization over the Internet or integration with anonymous user systems acting as cracking clients. By focusing on secure, centralized, and high-performance environments, Hash Slinger delivers tailored scalability and efficiency to meet the demands of sophisticated cracking operations.

## Technologies Used

HashSlinger employs a variety of technologies and tools to achieve performance and scalability:

- **[ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)**: A high-performance, cross-platform framework for building modern, cloud-based, and internet-connected applications.
- **[C#](https://docs.microsoft.com/en-us/dotnet/csharp/)**: The primary programming language for the backend, known for its robustness and versatility.
- **[PostgreSQL](https://www.postgresql.org/)**: A powerful, open-source object-relational database system that uses and extends the SQL language.
- **[Docker](https://www.docker.com/)**: Ensuring that HashSlinger is containerized, which means dividing the application into several docker containers such as the web interface, backend API, background worker processes, and the database.
- **[Mapster](https://github.com/MapsterMapper/Mapster)**: An object-to-object mapping library, Mapster is used to parse between different data models efficiently.
- **[MediatR](https://github.com/jbogard/MediatR)**: A library that implements the Mediator pattern, helping in creating a clean architecture by decoupling the handling of HTTP requests from the business logic.
- **[Microsoft Visual Studio](https://visualstudio.microsoft.com/)**: A powerful integrated development environment (IDE) used for developing the application.
- **[Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)**: A modern object-database mapper for .NET, it supports LINQ queries, change tracking, updates, and schema migrations.

After extensive testing, .NET was determined to be the most performant option for building this complex multi-tier system, thanks to its features like asynchronous programming, garbage collection, and strong integration with various libraries and tools.

## Roadmap

**Phase 1: Initial Infrastructure and Setup**

- [x] Milestone 1: Create infrastructure for registering Hashtopolis agents.
- [ ] Milestone 2: Design and implement the automated setup of Hashtopolis agents, including downloading and uploading cracker binaries.

**Phase 2: Potfiles and Dictionary Tasks**

- [ ] Milestone 3: Develop the functionality for importing and exporting crack lists, including uploading and downloading potfiles.
- [ ] Milestone 4: Implement the creation and downloading of basic dictionary tasks, such as uploading and downloading wordlists and hashlists.

**Phase 3: Rule-Based Tasks and Mask Tasks**

- [ ] Milestone 5: Design and implement the creation of rule-based tasks, including the uploading of rulesets and hashlists.
- [ ] Milestone 6: Implement the creation of mask tasks, including the uploading of masks and hashlists.

**Phase 4: Containerization**

- [ ] Milestone 7: Develop Docker configurations for each component of Hash Slinger.
- [ ] Milestone 8: Test Docker deployment and document the process.

**Phase 5: User Interface and Experience Development**

- [ ] Milestone 9: Design and implement the initial user interface.
- [ ] Milestone 10: Conduct usability testing and incorporate user feedback to improve the interface and user experience.

**Phase 6: Advanced Features and Integrations**

- [ ] Milestone 11: Develop advanced features such as the ability to assign systems to different projects, allowing prioritized job cracking based on project requirements.
- [ ] Milestone 12: Implement and ensure compatibility with the Hashtopolis Communication Protocol v2.

**Phase 7: Security and Performance**

- [ ] Milestone 13: Implement security measures and conduct security audits.
- [ ] Milestone 14: Performance benchmarking, testing, and optimization.

**Phase 8: Documentation and Support**

- [ ] Milestone 15: Complete essential documentation (user guides, API documentation, etc.).
- [ ] Milestone 16: Establish a basic user support system.

**Phase 9: Iterative Testing and Refinement**

- [ ] Milestone 17: Iterative design, development, testing, and review cycles to improve functionality, usability, and performance.

**Phase 10: Release Preparation and Distribution**

- [ ] Milestone 18: Conduct final comprehensive testing to ensure Hash Slinger functions as intended and performs optimally under the target use cases.
- [ ] Milestone 19: Prepare and distribute the initial public release.

## Hashtopolis API Implementation

- [x] TestConnection
- [x] Register
- [x] UpdateInformation
- [x] Login
- [x] CheckClientVersion
- [x] DownloadBinary
- [ ] ClientError
- [ ] GetFile
- [x] GetHashlist
- [ ] GetTask
- [ ] GetChunk
- [ ] SendKeyspace
- [ ] SendBenchmark
- [ ] SendProgress
- [x] GetFileStatus
- [x] GetHealthCheck
- [x] SendHealthCheck
- [ ] Deregister

## Contributing

Contributions are always welcome! For guidance on contributing, please check `CONTRIBUTING.md`. Make sure to adhere to this project's `code of conduct`.

## Acknowledgements

- We would like to acknowledge the [Hashtopolis](https://github.com/hashtopolis/server) team for inspiring us and providing us with the [Hashtopolis Communication Protocol v2](https://github.com/hashtopolis/server/blob/master/doc/protocol.pdf) documentation.
- Our sincere thanks to [Hashcat](https://github.com/hashcat/hashcat) for their incredible cracking tool.

## License

This project is licensed under [GPL-3.0](https://choosealicense.com/licenses/gpl-3.0/).
