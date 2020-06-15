<template>
	<v-app>
		<Nav/>
		<v-main>
			<v-container fluid>
				<nuxt/>
			</v-container>
		</v-main>
	</v-app>
</template>

<script>
	import Nav from '~/components/layout/Nav'

	export default
	{
		components: { Nav }
	}
</script>
