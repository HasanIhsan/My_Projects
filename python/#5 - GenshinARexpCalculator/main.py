#!/usr/bin/env python

# simple "how many days assuming i do dailies and use all my resin (180 per day) i need until AR n"
# This only works starting from AR40 (will update later to work for all AR lvls) 

# enter the required information
my_current_AR_exp =  int(input("Enter your current AR exp: "))
my_current_AR = int(input("Enter your current AR: "))
wanted_AR = int(input("Enter what AR your aiming for (40 - 60): "))

# exp table with the exps for that current AR
ADVENTURE_RANK_EXP_TABLE = {
    40: 145375,
    41: 155925,
    42: 167450,
    43: 179925,
    44: 193375,
    45: 207775,
    46: 223125,
    47: 239450,
    48: 256725,
    49: 274975,
    50: 294175,
    51: 320575,
    52: 349375,
    53: 380575,
    54: 414175,
    55: 450175,
    56: 682525,
    57: 941500,
    58: 1227250,
    59: 154075,
    60: 1880200,
} 


RESIN_USAGE_PER_DAY = 180
EXP_PER_20_RESIN = 100

RESIN_EXP_PER_DAY = RESIN_USAGE_PER_DAY / 20 * EXP_PER_20_RESIN
DAILY_COMMISION_EXP = 500 + (4 * 250)

EXP_GAINED_PER_DAY = DAILY_COMMISION_EXP + RESIN_EXP_PER_DAY
TOTAL_EXP_REQUIRED = ADVENTURE_RANK_EXP_TABLE[wanted_AR] - ADVENTURE_RANK_EXP_TABLE[my_current_AR] - my_current_AR_exp

if TOTAL_EXP_REQUIRED < 0:
    print("Congrulations!!!, you have enough exp to get to that rank")
else:
    print(f"TOTAL exp Required: {TOTAL_EXP_REQUIRED}")
    print(f"est. days until goal AR: {TOTAL_EXP_REQUIRED / EXP_GAINED_PER_DAY}")
    
 