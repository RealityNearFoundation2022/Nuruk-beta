# Spatial Integration Problem (May sixth)

## Description

- In a game called "Nuruk", have planned to integrate the spatial audio to the voice chat. What is currently in use, to avoid people listening all the conversations taking place around the world, is a triggering-event strategy to enter a different voice channel by each map zone. But the technology we are working on, has limitations and there are plenty of bugs, if the swap between audio channels are not handled correctly, bringing more complexity to the integration of the spatial audio.

## Question

- Is it benefitial to maintain the triggering-event strategy and add on top of that, the spatial audio or is better to eliminate the existing strategy and just improve calculations times (Calculations that are constantly called by frame) filtering the people that are to far away?
