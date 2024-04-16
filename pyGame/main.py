import random
import pygame

pygame.init()

window_width = 800
window_height = 600
window = pygame.display.set_mode((window_width, window_height))

class Player:
	def __init__(self, x, y, size, color, speed=10, score=0):
		self.x = x
		self.y = y
		self.size = size
		self.color = color
		self.speed = speed
		self.score = score
	def checkBounds(self):
		if self.x < 0:
			self.x = 0
		if self.x > window_width - self.size:
			self.x = window_width - self.size
		if self.y < 0:
			self.y = 0
		if self.y > window_height - self.size:
			self.y = window_height - self.size
	def moveRight(self):
		self.x += self.speed
	def moveLeft(self):
		self.x -= self.speed
	def moveUp(self):
		self.y -= self.speed
	def moveDown(self):
		self.y += self.speed

class Apple:
	def __init__(self,size, color):
    #  position is random
		self.x = random.randint(0, window_width - size)
		self.y = random.randint(0, window_height - size)
		self.size = size
		self.color = color
  
apples = []

 
pOne = Player(70, 50, 50, (20, 200, 20))
pTwo = Player(700, 500, 50, (200, 20, 20))

def handleKeys(keys):
	if keys[pygame.K_RIGHT] : 
		pOne.moveRight()
	if keys[pygame.K_LEFT] :
		pOne.moveLeft()
	if keys[pygame.K_UP] :  
		pOne.moveUp()
	if keys[pygame.K_DOWN] :  
		pOne.moveDown()
	if keys[pygame.K_d]: 
		pTwo.moveRight()
	if keys[pygame.K_a]:
		pTwo.moveLeft()
	if keys[pygame.K_w]:  
		pTwo.moveUp()
	if keys[pygame.K_s]:  
		pTwo.moveDown()		
	pOne.checkBounds()
	pTwo.checkBounds()

run = True
delta = 0
while run:
	pygame.time.Clock().tick(60)  
	for event in pygame.event.get():
		if event.type == pygame.QUIT:  
			run = False

 
	delta += 1
 
	if delta == 160:
		delta = 0
		if len(apples) < 3:
			apples.append(Apple(20, (200, 20, 20)))
  
 
	
	keys = pygame.key.get_pressed()
	
	handleKeys(keys)

	window.fill((24, 164, 240))  
	pygame.draw.rect(window, (20, 200, 20), pygame.rect.Rect(pOne.x, pOne.y, pOne.size, pOne.size))  
	pygame.draw.rect(window, (200, 20, 20), pygame.rect.Rect(pTwo.x, pTwo.y, pTwo.size, pTwo.size))  
	for apple in apples:
		pygame.draw.rect(window, apple.color, pygame.rect.Rect(apple.x, apple.y, apple.size, apple.size))
		if pOne.x < apple.x + apple.size and pOne.x + pOne.size > apple.x and pOne.y < apple.y + apple.size and pOne.y + pOne.size > apple.y:
			pOne.score += 1
			apples.remove(apple)
		if pTwo.x < apple.x + apple.size and pTwo.x + pTwo.size > apple.x and pTwo.y < apple.y + apple.size and pTwo.y + pTwo.size > apple.y:
			pTwo.score += 1
			apples.remove(apple)
   
#    Render the score
	font = pygame.font.Font(None, 36)
	
	window.blit(font.render(f"Player 1: {pOne.score}", True, (255, 255, 255)), (10, 10))
	
	window.blit(font.render(f"Player 2: {pTwo.score}", True, (255, 255, 255)), (10, 40))
    
	pygame.display.update()