from random import random


def prepare_aliased_randomizer(weights):
    n = len(weights)
    avg = sum(weights) / n
    aliases = [(1, None)] * n
    smalls = ((i, w / avg) for i, w in enumerate(weights) if w < avg)
    bigs = ((i, w / avg) for i, w in enumerate(weights) if w >= avg)
    small, big = next(smalls, None), next(bigs, None)
    while big and small:
        aliases[small[0]] = (small[1], big[0])
        big = (big[0], big[1] - (1 - small[1]))
        if big[1] < 1:
            small = big
            big = next(bigs, None)
        else:
            small = next(smalls, None)

    def weighted_random():
        r = random() * n
        i = int(r)
        odds, alias = aliases[i]
        return alias if (r - i) > odds else i

    return weighted_random
