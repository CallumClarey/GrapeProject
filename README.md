# GRAPE 
A C#based game engine built on a fondation of a hybrid aritechure using a mixture of both ECS and Entity Component. 
## Hybrid ECS Engine Architecture

A high-performance C# game engine core utilizing a Hybrid Data-Oriented Architecture. This engine combines the developer-friendly abstraction of Entity-Component (EC) with the cache-efficient, SIMD-ready power of a Component System (ECS).
The Hybrid Philosophy

This engine splits logic into two idologies 

    The ECS Performance: High-frequency data (Transforms, Physics, Rendering) is stored in Blittable Structs within contiguous memory buffers. Systems iterate over these buffers in linear passes to maximize CPU cache hits.

    The EC Tier Game Logic: Game logic and abstracted behaviors are managed via traditional GameObject abstractions.

## Technology Stack
Currently the project is going to use avalonia for the game engine UI and be written primarly in c# intially with plans to migrate the render to c++.
