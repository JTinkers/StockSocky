<template>
	<v-navigation-drawer color='#063A46' permament dark app>
		<v-list-item>
			<v-list-item-content>
				<v-list-item-title class='title' v-text='"StockSocky"'/>
				<v-list-item-subtitle v-text='"A lightweight stock tracking app"'/>
			</v-list-item-content>
		</v-list-item>
		<v-list nav dense>
			<v-list-item to='/' nuxt link>
				<v-list-item-icon>
					<v-icon v-text='"mdi-finance"'/>
				</v-list-item-icon>
				<v-list-item-content>
					<v-list-item-title v-text='"Tracker"'/>
				</v-list-item-content>
			</v-list-item>
			<v-list-item to='/settings' nuxt link>
				<v-list-item-icon>
					<v-icon v-text='"mdi-cog"'/>
				</v-list-item-icon>
				<v-list-item-content>
					<v-list-item-title v-text='"Settings"'/>
				</v-list-item-content>
			</v-list-item>
			<v-list-item href='https://github.com/JTinkers/StockSocky' link>
				<v-list-item-icon>
					<v-icon v-text='"mdi-github"'/>
				</v-list-item-icon>
				<v-list-item-content>
					<v-list-item-title v-text='"Project"'/>
				</v-list-item-content>
			</v-list-item>
		</v-list>
	</v-navigation-drawer>
</template>
