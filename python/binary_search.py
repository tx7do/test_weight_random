import itertools
from random import random


def prepare_binary_search(weights):
    # Computing the running totals takes O(N) time
    running_totals = list(itertools.accumulate(weights))

    def weighted_random():
        target_distance = random() * running_totals[-1]
        low, high = 0, len(weights)
        while low < high:
            mid = int((low + high) / 2)
            distance = running_totals[mid]
            if distance < target_distance:
                low = mid + 1
            elif distance > target_distance:
                high = mid
            else:
                return mid
        return low

    return weighted_random
