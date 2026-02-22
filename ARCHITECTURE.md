# Architecture Overview

SingaporePay follows Clean Architecture principles.

## Layers

### Domain

Contains business rules and entities.

### Application

Handles use cases and orchestration.

### Infrastructure

Handles persistence and external integrations.

### API

Transport layer exposing HTTP endpoints.

## Design Principles

* Dependency Inversion
* Separation of Concerns
* Domain Isolation
* Replaceable Infrastructure

