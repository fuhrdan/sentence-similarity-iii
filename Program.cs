//*****************************************************************************
//**  1813 Sentence Similarity III    leetcode                               **
//*****************************************************************************


bool areSentencesSimilar(char* sentence1, char* sentence2) {
    // Find the length of both strings
    int len1 = strlen(sentence1);
    int len2 = strlen(sentence2);

    // Ensure sentence1 is the longer one, swap if necessary
    if (len1 < len2) {
        char* tmp = sentence1;
        sentence1 = sentence2;
        sentence2 = tmp;
        
        int tempLen = len1;
        len1 = len2;
        len2 = tempLen;
    }

    // Tokenize the strings into word arrays using space as a delimiter
    char *arr1[100], *arr2[100];  // Arrays to hold the words
    int idx1 = 0, idx2 = 0;
    
    char* token = strtok(sentence1, " ");
    while (token != NULL) {
        arr1[idx1++] = token;
        token = strtok(NULL, " ");
    }
    
    token = strtok(sentence2, " ");
    while (token != NULL) {
        arr2[idx2++] = token;
        token = strtok(NULL, " ");
    }

    len1 = idx1;
    len2 = idx2;

    // Initialize indices to track non-matching portions
    int leftIdx = -1, rightIdx = -1;

    // Check from the left for differences
    for (int i = 0; i < len2; i++) {
        if (strcmp(arr1[i], arr2[i]) != 0) {
            leftIdx = i;
            break;
        }
    }

    // Check from the right for differences
    for (int i = 0; i < len2; i++) {
        if (strcmp(arr1[len1 - i - 1], arr2[len2 - i - 1]) != 0) {
            rightIdx = len2 - i - 1;
            break;
        }
    }

    // If either index is unchanged, the sentences are similar
    if (leftIdx == -1 || rightIdx == -1) {
        return true;
    }

    // If leftIdx is greater than rightIdx, the sentences are similar
    return leftIdx > rightIdx;
}