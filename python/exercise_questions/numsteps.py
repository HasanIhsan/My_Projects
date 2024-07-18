#number of steps to reduce a number to zero
#given an int, reutrn the number of steps to reduct it to 0


#ex: 14 output: 6
#     8 output 4
#     0 output 0


def numsteps(num: int):
    print(num)
    steps = 0
    
    while num > 0:
        if num % 2 == 0:
            num /= 2
        else:
            num -= 1
            
        steps += 1
            
 
    
    
    return steps
    
    

if __name__ == "__main__":
    print("steps")
    num = 14
    print(numsteps(num))