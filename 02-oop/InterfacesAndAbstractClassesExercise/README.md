# Group Activity: Electronic Devices Hierarchy
Today, we'll be putting into practice all that we've learned about Object Oriented Programming in C#.

## Scenario:
A tech company wants to catalog their electronic devices and manage their rechargeable devices. Each device should be able to turn on and off. Rechargeable devices should have a method to recharge them.

## Objective
Create a base ElectronicDevice class and at least three subclasses that inherit from ElectronicDevice. Implement methods to demonstrate the functionality of the devices. Additionally, introduce an interface IRechargeable to add rechargeable capabilities to some of the devices.

## Steps to Complete
1. **Define the Abstract Base Class:**
Each group will start by defining an abstract base `ElectronicDevice` class with properties like `Brand`, `Model`, and two abstract methods, `TurnOn` and `TurnOff`.
2. **Create Subclasses:**
Each group will create at least three subclasses that inherit from `ElectronicDevice`. Each subclass should represent a different type of electronic device.
Subclasses could include `Smartphone`, `Laptop`, and `Television`, for instance, each implementing the abstract methods defined in the base class.
3. **Implement Methods:**
Each subclass should contain methods unique to that subclass to demonstrate the functionality of the device.
4. **Interface Implementation:**
Introduce an interface `IRechargeable` with a method `Recharge`. Some, but not all, of the subclasses should implement this interface. A ``Television` subclass, for example, would not implement this interface.
5. **Polymorphism and Interface Usage:**
Demonstrate polymorphism by creating a list of `ElectronicDevice` objects and calling methods on the base class reference.
Show how the `IRechargeable` interface is used by creating a list of `IRechargeable` objects.