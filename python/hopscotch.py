import itertools
from random import random


def prepare_hopscotch_selection(weights):
    # This preparation will run in O(N*log(N)) time,
    # or however long it takes to sort your weights
    sorted_indices = sorted(range(len(weights)),
                            reverse=True,
                            key=lambda i: weights[i])

    sorted_weights = [weights[s] for s in sorted_indices]
    running_totals = list(itertools.accumulate(sorted_weights))

    def weighted_random():
        target_dist = random() * running_totals[-1]
        guess_index = 0
        while True:
            if running_totals[guess_index] > target_dist:
                return sorted_indices[guess_index]
            weight = sorted_weights[guess_index]
            # All weights after guess_index are <= weight, so
            # we need to hop at least this far to reach target_dist
            hop_distance = target_dist - running_totals[guess_index]
            hop_indices = 1 + int(hop_distance / weight)
            guess_index += hop_indices

    return weighted_random
