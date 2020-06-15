<template>
	<v-navigation-drawer color='#063A46' permament dark app>
		<v-list-item>
			<v-list-item-content>
				<v-list-item-title class='title' v-text='"StockSocky"'/>
				<v-list-item-subtitle v-text='"A lightweight stock tracking app"'/>
			</v-list-item-content>
		</v-list-item>
		<v-list nav dense>
			<v-list-item v-for='(route, i) in routes' :key='i' :to='route.to' :href='route.href' nuxt link>
				<v-list-item-icon>
					<v-icon v-text='route.icon'/>
				</v-list-item-icon>
				<v-list-item-content>
					<v-list-item-title v-text='route.name'/>
				</v-list-item-content>
			</v-list-item>
		</v-list>
	</v-navigation-drawer>
</template>

<script>
	export default
	{
		data: () =>
		({
			routes:
			[
				{
					name: 'Stocks',
					icon: 'mdi-finance',
					to: '/'
				},
				{
					name: 'Transactions',
					icon: 'mdi-plus-minus',
					to: '/transactions'
				},
				{
					name: 'Settings',
					icon: 'mdi-cog',
					to: '/settings'
				},
				{
					name: 'Project',
					icon: 'mdi-github',
					href: 'https://github.com/JTinkers/StockSocky'
				}
			]
		})
	}
</script>
