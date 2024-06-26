#given an 32 bit int reverse the value
#ex: value = 123
#output: 321


#first thng that went through my mind
def reverse_intV1(value):
    print(value)
    
    arr = list(map(int, str(value))) #convert the int to array
    print(arr)
    
    
    #revere the array (arr) and add the items to arr2
    arr2 = [] 
    for i in reversed(arr):
        arr2.append(i)
        
    
    print(arr2)
    
    #convert the array to a 32 int
    reversedvalue = int("".join([str(x) for x in arr2]))
    
    print(reversedvalue)
    
    #return the value
    return reversedvalue
        


if __name__ == "__main__":
    value = 123
    reversedval =  reverse_intV1(value)
    print(reversedval)