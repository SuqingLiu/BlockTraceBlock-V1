# BlockTraceBlock-V1
Created a game environment in Unity and trained with ML-Agents | Proximal Policy Optimization (PPO)

# Link to My Video

Instagram: https://www.instagram.com/reel/C3ypekuNhoJ/?igsh=MXAwZTB1NDUycW1qbg==

Tiktok: https://vm.tiktok.com/ZMMRHXHTT/

小红书: http://xhslink.com/G4JKeC

As I mentioned last time, I wanted to create my own simulated environment to train reinforcement learning agents. This is due to the limitations in terms of the information I can provide to the model in a captured environment. In this project, I learned the basics of Unity and closely followed the instructions from a great YouTube channel, The Ash Bot. https://youtu.be/RANRz9oyzko?si=TqWU1ERxnCjthEi_ Essentially, this is a reimagining of his project but with added reinforcement challenges, such as finding the fastest way for the agent to reach the target.

In this project, the environment is constructed in 2D and features an agent and a target. The agent's goal is to reach the target. Once the agent reaches the target, the game ends, and the agent wins. However, if the agent hits the wall on the edge of the map, the game ends, and the agent loses.

Therefore, it is straightforward to see that the objective for the agent is to reach the target. To increase difficulty and reduce potential bias in the algorithm, the spawning places of both the agent and the target are random but within a certain distance. In the rotated training model, we rotate the map because we want to train the agent from different angles.

To expedite the training, nine environments are set up to run simultaneously for each training session. The agents progressed from achieving single objectives, to mastering rotation, and finally to achieving rotation and finding the shortest distance.

The observations for the agent include the xy coordinates of itself and the target. The actions of the agent are to move along the x and y axes, which are continuous. Given the simplicity of the input, the Proximal Policy Optimization (PPO) method is better suited this time, as opposed to DQN.

The reward function for the first two settings remains unchanged: simply put, if the agent finds the target, it receives a reward of 10, and if it hits the wall, it gets -2. For the third mode, it's a bit more complicated because we want it to achieve the shortest distance. Therefore, a counter was created to count the number of steps the agent took before reaching the target, and we decrease the reward value by 0.1 per step. The reward is at least 10 for reaching the target, and hitting the wall still results in -1.

This is only version one because I plan to explore adding more walls to the map to create obstacles for the agent. I want the agent to navigate the path from start to finish while avoiding all obstacles. This will be version 2 of this project.
