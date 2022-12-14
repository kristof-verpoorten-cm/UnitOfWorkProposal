# UnitOfWorkProposal

Proposal how we can implement unit of work in our solution.

The repositories do not have to be aware if there is a transaction active or not.

Services can use any repository method with or without transaction.

This is the output when you run this program:

```
CREATE A PURCHASE WITHOUT TRANSACTION
=====================================
Creating purchase with id 4d4f9a73-453a-4243-b78d-ce4d0c2bf95e
IWriteEntities for context with ID 20fd1254-b634-45f5-9c93-0dac32af4f44: Creating a new purchase
IWriteEntities for context with ID 20fd1254-b634-45f5-9c93-0dac32af4f44: SaveChanges()



CREATE A PURCHASE AND PURCHASEITEMS WITH A TRANSACTION
======================================================
Creating purchase with id 1a3f55f2-910f-45c9-bf13-cc914e2ef1ac
IWriteEntities for context with ID 37e0ecfd-0574-46c7-99fc-fdcf5395f3c5: Creating a new purchase
Reading purchase with id 1a3f55f2-910f-45c9-bf13-cc914e2ef1ac
IReadEntities for context with ID 37e0ecfd-0574-46c7-99fc-fdcf5395f3c5: Reading data
Create purchaseItem for purchase with id 1a3f55f2-910f-45c9-bf13-cc914e2ef1ac
IWriteEntities for context with ID 37e0ecfd-0574-46c7-99fc-fdcf5395f3c5: Creating a new purchase item
Create purchaseItem for purchase with id 1a3f55f2-910f-45c9-bf13-cc914e2ef1ac
IWriteEntities for context with ID 37e0ecfd-0574-46c7-99fc-fdcf5395f3c5: Creating a new purchase item
Create purchaseItem for purchase with id 1a3f55f2-910f-45c9-bf13-cc914e2ef1ac
IWriteEntities for context with ID 37e0ecfd-0574-46c7-99fc-fdcf5395f3c5: Creating a new purchase item
IWriteEntities for context with ID 37e0ecfd-0574-46c7-99fc-fdcf5395f3c5: SaveChanges()



CREATE A PURCHASEITEM FOR AN EXISTING PURCHASE WITHOUT A TRANSACTION
==========================================================================
Create purchaseItem for purchase with id 1a3f55f2-910f-45c9-bf13-cc914e2ef1ac
IWriteEntities for context with ID d3bc6369-3538-459f-aad1-8635f5f76fa4: Creating a new purchase item
IWriteEntities for context with ID d3bc6369-3538-459f-aad1-8635f5f76fa4: SaveChanges()```
