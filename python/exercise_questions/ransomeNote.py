#leetcode: 383. Ransome Note
# given two stings ransomeNote and magazine
# return true if ransomeNote can be constructed by using the letter 
#   from magazine and false otherwise

# each letter in magazine can only be used once in ransomeNote

#ex: input: ransomNote = "aa", magazine = "ab"
#   output: false

#   input: ransomNote = "aa", magazine = "aab"
#   output: true


def canRansomNote(ransomNote, magazine):
    arri = {}
    
   #? arr = list(ransomNote)
   #? arr2 = list(magazine)
   
   # iterate through the magazine
   # count the amount of times letters seen
    for c in magazine:
        if c not in arri:
            arri[c] = 1
        else:
            arri[c] +=1
   
   # iterate through the ransomNote
   # and check the letter count
    for c in ransomNote:
        if c in arri and arri[c] > 0:
            arri[c] -= 1
        else:
            return False
        
    return True
       
                
       
    
    return False


if __name__ == "__main__":
    ransomNote = "aa"
    magazine = "ab"
    
    print( canRansomNote(ransomNote, magazine))